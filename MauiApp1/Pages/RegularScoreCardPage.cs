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
        public List<int> Scores = new List<int>();
        public RegularScoreViewModel model; 
        public RegularScoreCardPage()
        {
            InitializeComponent();
            model = new RegularScoreViewModel(); 

        }
    }

