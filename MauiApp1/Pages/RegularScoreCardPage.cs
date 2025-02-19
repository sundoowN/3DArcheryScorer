using System;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using MauiApp1.Models;
using MauiApp1.Pages;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace MauiApp1.Pages;
    public partial class RegularScoreCardPage : ContentPage
    {
        //public List<int> Scores = new List<int>();
        public List<int> ScoreTallyTotal = new List<int>(); 
        public RegularScoreViewModel model; 
        public RegularScoreCardPage()
        {
            InitializeComponent();
            model = new RegularScoreViewModel(); 
            BindingContext = model; 
        }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker?.SelectedItem != null)
        {
            if (int.TryParse(picker.SelectedItem.ToString(), out int selectedScore))
            {
                ScoreTallyTotal.Add(selectedScore);
            }
        }
    }
}

