﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Icarus.Models;
using Newtonsoft.Json;

namespace Icarus.Data
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public List<Fuel> Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Fuel>> RefreshDataAsync()
        {
            Items = new List<Fuel>();

            var uri = new Uri(string.Format(Constants.GenerationStats, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var generationMix = JsonConvert.DeserializeObject<CarbonMixReponse>(content);
                    // Convert to Fuel model
                    Items = generationMix.data.generationmix.Select(x => new Fuel(x.fuel, x.perc)).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        //public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        //{
        //    var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(item);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = null;
        //        if (isNewItem)
        //        {
        //            response = await _client.PostAsync(uri, content);
        //        }
        //        else
        //        {
        //            response = await _client.PutAsync(uri, content);
        //        }

        //        if (response.IsSuccessStatusCode)
        //        {
        //            Debug.WriteLine(@"\tTodoItem successfully saved.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }
        //}

        //public async Task DeleteTodoItemAsync(string id)
        //{
        //    var uri = new Uri(string.Format(Constants.TodoItemsUrl, id));

        //    try
        //    {
        //        var response = await _client.DeleteAsync(uri);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            Debug.WriteLine(@"\tTodoItem successfully deleted.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }
        //}
    }
}
