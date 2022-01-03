using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using LabControllerSim.Core.Parameters;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace LabControllerSim.Modules.Compilation.ViewModels
{
    public class ErrorListViewModel : BindableBase
    {
        
        private string _compilationOutput;
        public string CompilationOutput
        {
            get { return _compilationOutput; }
            set { SetProperty(ref _compilationOutput, value); }
        }

        public ErrorListViewModel(IEventAggregator ea)
        {
            ea.GetEvent<CodeCompileEvent>().Subscribe(compile);
            ea.GetEvent<CodeCheckErrorsEvent>().Subscribe(checkErrors);
        }

        private void checkErrors(CodeCompileEventParameters codeCompileEventParameters)
        {
            string errors = checkErrorsProcess(codeCompileEventParameters);
            string FileName = codeCompileEventParameters.FileName;
            string FilePath = codeCompileEventParameters.FilePath;
            if (string.IsNullOrEmpty(errors)) errors = "Nie znaleziono błędów.";
            CompilationOutput = $"Nazwa Pliku: {FileName} \nŚcieżka pliku: {FilePath} \nErrors: \n{errors}";
        }

        private void compile(CodeCompileEventParameters codeCompileEventParameters)
        {
            string FileName = codeCompileEventParameters.FileName;
            string FilePath = codeCompileEventParameters.FilePath;
            
            Process compilerProcess = new Process();
            compilerProcess.StartInfo.FileName = @"Compiler\bin\gcc.exe";
            //  string path = System.IO.Path.GetFullPath(Assembly.GetEntryAssembly().Location);
            // MessageBox.Show(path);
            string tempFileName = $"{GetUniqueKey()}.c";
            string tempFilePath = FilePath.Replace(FileName, tempFileName);
            string filePathWithoutExtension = FilePath.Replace(".c", "");
            string fileNamehWithoutExtension = FileName.Replace(".c", "");
            string Text = AddCoummunication(File.ReadAllText(FilePath));
            File.WriteAllText(tempFilePath, Text);
            compilerProcess.StartInfo.Arguments = $"{tempFilePath} -o {filePathWithoutExtension}";
            compilerProcess.StartInfo.CreateNoWindow = true;
            compilerProcess.StartInfo.RedirectStandardError = true;
            compilerProcess.StartInfo.UseShellExecute = false;
            compilerProcess.Start();
            compilerProcess.WaitForExit();
            File.Delete(tempFilePath);
            string errors = checkErrorsProcess(codeCompileEventParameters);
            if (string.IsNullOrEmpty(errors))
            {
                CompilationOutput = $"Plik wykonywalny {fileNamehWithoutExtension}.exe został utworzony. \nScieżka źródłowa pliku: {filePathWithoutExtension}.exe.";
            }
            else
            {
                CompilationOutput = $"Nazwa Pliku: {FileName} \nŚcieżka pliku: {FilePath} \nErrors: \n{errors}";
            }
        }

        private string AddCoummunication(string text)
        {
            string newText = text;
            bool found = false;
            int inputPlaceIndex;
            int count = 0;
            int outputPlaceIndex=0;
            newText = AddDeclaration(newText);
            int startIndex = newText.IndexOf("while");
            do
            {
                for(int i=startIndex;i< newText.Length;i++)
                {
                    if(newText[i].ToString() != " ")
                    {
                        found = newText.IndexOf("(1)",i,3) == -1 ? false : true;
                        if (found) 
                        {
                            startIndex = i;
                            break;
                        }
                    } 
                }

            } while (!found);
            inputPlaceIndex = newText.IndexOf("{",startIndex, newText.Length-startIndex)+1;
            newText = newText.Insert(inputPlaceIndex, InputString());
            for(int i = inputPlaceIndex; i < newText.Length; i++)
            {
                if (newText[i].ToString() == "{")
                {
                    count++;
                }
                else if (newText[i].ToString() == "}")
                {
                    count--; 
                }
                if (count < 0)
                {
                    outputPlaceIndex = i - 1;
                    break;
                }
            }
            newText = newText.Insert(outputPlaceIndex,OutputString());
            return newText;
        }

        private string checkErrorsProcess(CodeCompileEventParameters codeCompileEventParameters)
        {
            string FileName = codeCompileEventParameters.FileName;
            string FilePath = codeCompileEventParameters.FilePath;
            string tempFileName = $"{GetUniqueKey()}.c";
            string tempFilePath = FilePath.Replace(FileName, tempFileName);
            string Text = File.ReadAllText(FilePath);
            int startIndex = Text.IndexOf("main");
            Text = AddDeclaration(Text);
            File.WriteAllText(tempFilePath, Text);
            Process compilerProcess = new Process();
            compilerProcess.StartInfo.FileName = @"Compiler\bin\gcc.exe";
            compilerProcess.StartInfo.Arguments = $"{tempFilePath} -fsyntax-only";
            compilerProcess.StartInfo.CreateNoWindow = true;
            compilerProcess.StartInfo.RedirectStandardError = true;
            compilerProcess.StartInfo.UseShellExecute = false;
            compilerProcess.Start();
            compilerProcess.WaitForExit();
            File.Delete(tempFilePath);
            string errors = compilerProcess.StandardError.ReadToEnd();
            return errors;
        }
        private string AddDeclaration(string text)
        {
            string newText = text;
            int startIndex = newText.IndexOf("int");
            int declaractionPlaceIndex = 0;
            bool found = false;
            do
            {
                for (int i = startIndex+3; i < newText.Length-1; i++)
                {
                    if (newText[i].ToString() != " ")
                    {
                        found = newText.IndexOf("main", i,4) == -1 ? false : true;
                        if (found)
                        {
                            declaractionPlaceIndex = startIndex;
                            break;
                        }
                        else break;
                    }
                }
               // if(startIndex)
                startIndex = newText.IndexOf("int",startIndex+1);


            } while (!found);
            newText = newText.Insert(declaractionPlaceIndex, $"{DeclarationString()}{FunctionString()}");
            return newText;
        } 
        private string DeclarationString()
        {
            return "char _input[16] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},  _output[16] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},"
                +  "_inputChar[2], _outputChar[2], INPUT[8]={0,0,0,0,0,0,0,0}, OUTPUT[8]={0,0,0,0,0,0,0,0}, L1=0 , L2=0, L3=0, L4=0, L5=0, L6=0, L7=0, L8=0, aK1, aK2, aK3, aK4, aK5, aK6, aK7, aK8; ";
        }
        private string InputString()
        {
            return "scanf(\"%s\",_input); scanf(\"%s\",_inputChar); \naK1 = _input[0]-'0'; aK2 = _input[1]-'0'; aK3 = _input[2]-'0'; aK4 = _input[3]-'0'; aK5 = _input[4]-'0'; aK6 = _input[5]-'0'; aK7 = _input[6]-'0';"
                + " aK8 = _input[7]-'0';  INPUT[0] = _input[8]-'0'; INPUT[1] = _input[9]-'0'; INPUT[2] = _input[10]-'0'; INPUT[3] = _input[11]-'0'; INPUT[4] = _input[12]-'0'; INPUT[5] = _input[13]-'0';"
                + " INPUT[6] = _input[14]-'0'; INPUT[7] = _input[15]-'0';";
        }

        private string OutputString()
        {
            return "_output[0] = L1 + '0'; _output[1] = L2 + '0'; _output[2] = L3 + '0'; _output[3] = L4 + '0'; _output[4] = L5 + '0'; _output[5] = L6 + '0';"
                + " _output[6] = L7 + '0'; _output[7] = L8 + '0'; _output[8] = OUTPUT[0] + '0'; _output[9] = OUTPUT[1] + '0'; _output[10] = OUTPUT[2] + '0'; _output[11] = OUTPUT[3] + '0';"
                + " _output[12] = OUTPUT[4] + '0'; _output[13] = OUTPUT[5] + '0'; _output[14] = OUTPUT[6] + '0'; _output[15] = OUTPUT[7] + '0';"
                + "write(1, _output, 16); write(1, \"\\n\", 1); ";
        }
        private string FunctionString()
        {
            return "char COM_recv(void) { return _inputChar[0]; } void COM_send(char charToSend) { _outputChar[0] = charToSend; write(1, \"COM\", 3); write(1, _outputChar, 1); write(1, \"\\n\", 1); } ";
        }
        private string GetUniqueKey()
        {
            int size = 16;
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }
    }
}
