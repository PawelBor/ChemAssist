using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;

namespace ChemistryAssistant
{
    public class Library
    {
        private void focus(ref RichEditBox display)
        {
            display.Focus(Windows.UI.Xaml.FocusState.Keyboard);

        }

        private void set(ref RichEditBox display, string value)
        {
            display.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, value);
            focus(ref display);
        }

        public string get(ref RichEditBox display)
        {
            string value = string.Empty;
            display.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out value);
            return value;
        }
        public async Task<bool> Confirm(string content, string title, string ok, string cancel)
        {
            bool result = false;
            MessageDialog dialog = new MessageDialog(content, title);
            dialog.Commands.Add(new UICommand(ok, new UICommandInvokedHandler((cmd) => result = true)));
            dialog.Commands.Add(new UICommand(cancel, new UICommandInvokedHandler((cmd) => result = false)));
            await dialog.ShowAsync();
            return result;
        }

        //thickBold
        public bool Bold(ref RichEditBox display)
        {
            display.Document.Selection.CharacterFormat.Bold = Windows.UI.Text.FormatEffect.Toggle;
            focus(ref display);
            return display.Document.Selection.CharacterFormat.Bold.Equals(FormatEffect.On);
        }
        //slant
        public bool Italic(ref RichEditBox display)
        {
            display.Document.Selection.CharacterFormat.Italic = Windows.UI.Text.FormatEffect.Toggle;
            focus(ref display);
            return display.Document.Selection.CharacterFormat.Italic.Equals(FormatEffect.On);
        }
        //adds underline to text
        public bool Underline(ref RichEditBox display)
        {
            display.Document.Selection.CharacterFormat.Underline = display.Document.Selection.CharacterFormat.Underline.Equals(UnderlineType.Single) ? UnderlineType.None : UnderlineType.Single;
            focus(ref display);
            return display.Document.Selection.CharacterFormat.Underline.Equals(FormatEffect.On);
        }
        //moves text to left side of editBox
        public bool Left(ref RichEditBox display)
        {
            display.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            focus(ref display);
            return display.Document.Selection.ParagraphFormat.Alignment.Equals(ParagraphAlignment.Left);
        }
        //centres editBox
        public bool Centre(ref RichEditBox display)
        {
            display.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            focus(ref display);
            return display.Document.Selection.ParagraphFormat.Alignment.Equals(ParagraphAlignment.Center);
        }

        //moves text to right of EditBox
        public bool Right(ref RichEditBox display)
        {
            display.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Right;
            focus(ref display);
            return display.Document.Selection.ParagraphFormat.Alignment.Equals(ParagraphAlignment.Right);
        }
        //changing size of text
        public void Size(ref RichEditBox display, ref ComboBox value)
        {
            if (display != null && value != null)
            {
                string selected = ((ComboBoxItem)value.SelectedItem).Tag.ToString();
                display.Document.Selection.CharacterFormat.Size = float.Parse(selected);
                focus(ref display);
            }
        }


        public async void New(RichEditBox display)
        {
            if (await Confirm("Create New Document?", "Rich Editor", "Yes", "No"))
            {
                set(ref display, string.Empty);
            }
        }

        //looks for file from filePicker
        public async void Open(RichEditBox display)
        {
            try
            {
                FileOpenPicker picker = new FileOpenPicker();
                picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                picker.FileTypeFilter.Add(".rtf");
                StorageFile file = await picker.PickSingleFileAsync();
                set(ref display, await FileIO.ReadTextAsync(file));
            }
            catch
            {

            }
        }

        //saves to default location, adds extension to file and suggested name "Document" - 
        public async void Save(RichEditBox display)
        {
            try
            {
                
                FileSavePicker picker = new FileSavePicker();
                picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                picker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });
                picker.DefaultFileExtension = ".rtf";
                picker.SuggestedFileName = "Document";
                
                StorageFile file = await picker.PickSaveFileAsync();
                if (file != null) // file not available
                {
                    CachedFileManager.DeferUpdates(file);
                    await FileIO.WriteTextAsync(file, get(ref display));
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                }
            }
            catch
            {

            }
        }
    }
}
