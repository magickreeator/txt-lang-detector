using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txt_lang_detector
{
    public partial class mainForm : Form
    {
        Func Functions = new Func();
        // Частотность букв русского языка ( https://ru.wikipedia.org/wiki/%D0%A7%D0%B0%D1%81%D1%82%D0%BE%D1%82%D0%BD%D0%BE%D1%81%D1%82%D1%8C )
        char[] ru = { 'о', 'е', 'a', 'и', 'н', 'т', 'с', 'р', 'в', 'л', 'к', 'м', 'д', 'п', 'у', 'я', 'ы', 'ь', 'г', 'з', 'б', 'ч', 'й', 'х', 'ж', 'ш', 'ю', 'ц', 'щ', 'э', 'ф', 'ъ', 'ё' };
        // Частотность букв английского языка ( https://en.wikipedia.org/wiki/Letter_frequency )
        char[] en = { 'e', 't', 'a', 'o', 'i', 'n', 's', 'h', 'r', 'd', 'l', 'c', 'u', 'm', 'w', 'f', 'g', 'y', 'p', 'b', 'v', 'k', 'j', 'x', 'q', 'z' };
        // Частотность букв украинского языка ( http://megamozg.ru/post/2336/ )
        char[] ua = { 'о', 'а', 'н', 'и', 'т', 'е', 'в', 'і', 'р', 'с', 'к', 'л', 'у', 'д', 'м', 'п', 'я', 'з', 'ь', 'б', 'г', 'ч', 'й', 'х', 'ж', 'ю', 'ш', 'ц', 'щ', 'є', 'ї', 'ф', '\'', 'ґ' };
        double rus, eng, ukr;
        public mainForm()
        {
            InitializeComponent();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.Text != "")
            {
                rus = Functions.detect(ru, richTextBox.Text.ToLower());
                eng = Functions.detect(en, richTextBox.Text.ToLower());
                ukr = Functions.detect(ua, richTextBox.Text.ToLower());

                if (rus > eng && rus > ukr)
                {
                    langNameLabel.Text = "Язык текста: русский";
                }
                else if (eng > rus && eng > ukr)
                {
                    langNameLabel.Text = "Язык текста: английский";
                }
                else if (ukr > rus && ukr > eng)
                {
                    langNameLabel.Text = "Язык текста: украинский";
                }
                else { langNameLabel.Text = "Язык текста: не удалось определить язык"; }
            }
            else
            {
                langNameLabel.Text = "Язык текста: ";
            }
        }
    }
}
