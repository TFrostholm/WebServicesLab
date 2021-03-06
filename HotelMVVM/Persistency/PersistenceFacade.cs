﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Windows.UI.Popups;
using HotelMVVM.Model;
using HotelMVVM.ViewModel;
using Newtonsoft.Json;

namespace HotelMVVM.Persistency
{
    /// <summary>
    ///  Works as a facade for the database and is responsible for connecting to the database
    /// </summary>
    class PersistenceFacade
    {
        const string ServerUrl = "http://localhost:50000";
        HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        /// <summary>
        /// Gets all hotels currently in the database
        /// </summary>
        /// <returns>Returns all hotels in list</returns>
        public List<Hotel> GetHotels()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        return hotelList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        /// <summary>
        /// Saves a new hotel to the database
        /// </summary>
        /// <param name="hotel">Pass in hotel that needs to be saved</param>
        public void SaveHotel(Hotel hotel)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(hotel);
                    var response =
                        client.PostAsync("api/Hotels", new StringContent(postBody, Encoding.UTF8, "application/json"))
                            .Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }

        /// <summary>
        /// Deletes a hotel from the database
        /// </summary>
        /// <param name="hotel">Pass in hotel that needs to be deleted</param>
        public void RemoveHotel(Hotel hotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.DeleteAsync("api/Hotels/" + hotel.Hotel_No).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// Updates existing hotel in the database
        /// </summary>
        /// <param name="hotel">Pass in hotel that needs to be updated</param>
        public void UpdateHotel(Hotel hotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(hotel);
                    var response =
                        client.PutAsync("api/Hotels/" + hotel.Hotel_No,
                            new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }


        /// <summary>
        /// Gets all rooms from all hotels
        /// </summary>
        public List<Room> GetRooms()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Rooms").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var roomList = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                        return roomList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public void SaveRoom(Room room)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(room);
                    var response =
                        client.PostAsync("api/Rooms", new StringContent(postBody, Encoding.UTF8, "application/json"))
                            .Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}


    