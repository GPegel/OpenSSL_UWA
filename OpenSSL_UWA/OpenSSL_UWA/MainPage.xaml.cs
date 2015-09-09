using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Globalization;

namespace OpenSSL_UWA
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //  i'm declaring all the variables and objects to use them in a array
            //  The reason for doing this is because I want the opensslCommandBox getting filled
            //  automatically when entering the values in the text and combo boxes.

            var commonName = commonNameTextBox.Text;
            var company = companyNameTextBox.Text;
            var department = departmentTextBox.Text;
            var email = eMailAddresTextBox.Text;
            var city = cityNameTextBox.Text;
            var stateProvince = stateProvinceTextBox.Text;

            //  The country, keysize and hash vars are not working in this way. I need another 
            //  solution for this.

            //var country = countryCombo.SelectedItem;
            //var keySize = keySizeCombo.SelectedItem;
            //var hash = hashAlgorithmCombo.SelectedItem;

            string[] commands = new string[]

            {
                "openssl req -new - sha256 - newkey rsa: " +
                keySize + " " + "- nodes -out " +
                commonName + ".csr" + " - keyout " + commonName + ".key" +
                " -subj " + " " +
                "'/C=" + countryCombo +
                "/ST=" + stateProvince +
                "/L=" + city +
                "/O=" + company +
                "/OU=" + department +
                "/CN=" + commonName +
                "/emailAddress=" + email + ""

            };

            //  This line is generated at OpenProvider and I've tested it and this works. 
            //  So the code above should do the trick
            //  openssl req -new - sha256 - newkey rsa: 4096 - nodes -out your.csr - keyout your.private.key -subj "/C=NL/ST=Overijssel/L=Enschede/O=GP Software/OU=IT/CN=www.gerhardpegel.nl/emailAddress=gpegel@gmail.com"


            foreach (string command in commands)

            {
                opensslCommandBox.Text = (command);

            }
        }

        //  This piece of code I'm going to use later to do a automatic population
        //  of the countryComboBox from an online service.

        //        public static List<string> CountryList()
        //{
        //    List<string> CultureList = new List<string>();
        //    CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        //    foreach (CultureInfo getCulture in getCultureInfo)
        //        RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);
        //    if (!(CultureList.Contains(GetRegionInfo.EnglishName)))
        //    {
        //        CultureList.Add(GetRegionInfo.EnglishName);

        //    }
        //    CultureList.Sort();
        //    return CultureList;

        //}

    }

}


