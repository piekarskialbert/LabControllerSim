using ICSharpCode.AvalonEdit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LabControllerSim
{
    public class AvalonTextEditor : TextEditor
    {
        #region EditText Dependency Property

        public static readonly DependencyProperty EditTextProperty =
            DependencyProperty.Register(
            "EditText",
            typeof(string),
            typeof(AvalonTextEditor),
            new UIPropertyMetadata(string.Empty, EditTextPropertyChanged));
        private static void EditTextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AvalonTextEditor editor = (AvalonTextEditor)sender;
            editor.Text = (string)e.NewValue;
        }
        public string EditText
        {
            get { return (string)GetValue(EditTextProperty); }
            set { SetValue(EditTextProperty, value); }
        }

        #endregion

        #region TextEditor Property

        public static TextEditor GetTextEditor(ContextMenu menu) { return (TextEditor)menu.GetValue(TextEditorProperty); }
        public static void SetTextEditor(ContextMenu menu, TextEditor value) { menu.SetValue(TextEditorProperty, value); }
        public static readonly DependencyProperty TextEditorProperty =
            DependencyProperty.RegisterAttached("TextEditor", typeof(TextEditor), typeof(AvalonTextEditor), new UIPropertyMetadata(null, OnTextEditorChanged));
        static void OnTextEditorChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            ContextMenu menu = depObj as ContextMenu;
            if (menu == null || e.NewValue is DependencyObject == false)
                return;
            TextEditor editor = (TextEditor)e.NewValue;
            NameScope.SetNameScope(menu, NameScope.GetNameScope(editor));
        }

        #endregion

        public AvalonTextEditor()
        {
            this.Loaded += new RoutedEventHandler(AvalonTextEditor_Loaded);
        }

        void AvalonTextEditor_Loaded(object sender, RoutedEventArgs e)
        {
            this.ContextMenu.SetValue(AvalonTextEditor.TextEditorProperty, this);
        }
    }
}
