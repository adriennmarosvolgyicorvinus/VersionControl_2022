using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GyakorlatLinq
{
    public partial class Form1 : Form
    {
        private List<Country> countries = new List<Country>();
        private List<Ramen> ramens = new List<Ramen>();
        private object txtCountryFilter;
        private object listCountries;

        public Form1()
        {
            InitializeComponent();
            LoadData("ramen.csv");

            listCountries.DisplayMember = "Name";
            GetCountries();
        }

        private void LoadData(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');

                    var countryName = line[2];
                    var currentCountry = (from c in countries
                                          where c.Name.Equals(countryName)
                                          select c).FirstOrDefault();
                    if (currentCountry == null)
                    {
                        currentCountry = new Country()
                        {
                            ID = countries.Count + 1,
                            Name = countryName
                        };
                        countries.Add(currentCountry);
                    }
                }

            }
        }

        
        private void LoadData(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');

                    var countryName = line[2];
                    AddCountry(countryName);
                }
            }
        }

        private void AddCountry(string countryName)
        {
            var currentCountry = (from c in countries
                                  where c.Name.Equals(countryName)
                                  select c).FirstOrDefault();
            if (currentCountry == null)
            {
                currentCountry = new Country()
                {
                    ID = countries.Count + 1,
                    Name = countryName
                };
                countries.Add(currentCountry);
            }
        }
        private void GetCountries()
        {
            var countriesList = from c in countries
                                where c.Name.Contains(txtCountryFilter.Text)
                                orderby c.Name
                                select c;
            listCountries.DataSource = countriesList.ToList();
        }
        private void txtCountryFilter_TextChanged(object sender, EventArgs e)
        {
            GetCountries();
        }


    }

}

