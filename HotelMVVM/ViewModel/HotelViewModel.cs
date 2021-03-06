﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HotelMVVM.Annotations;
using HotelMVVM.Common;
using HotelMVVM.Handler;
using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    public class HotelViewModel:INotifyPropertyChanged
    {

        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }
        public Handler.HotelHandler HotelHandler { get; set; }


        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
            //Creates an instance of the newHotel
            _newHotel = new Hotel();

            //Creates an instance of HotelHandler
            HotelHandler = new HotelHandler(this);

            //Creates instances of the RelayCommand
            CreateHotelCommand = new RelayCommand(HotelHandler.CreateHotel);

            DeleteHotelCommand = new RelayCommand(HotelHandler.DeleteHotel);

            UpdateHotelCommand = new RelayCommand(HotelHandler.EditHotel);
        }

        private Hotel _newHotel;

        public ICommand _createHotelCommand;
        public ICommand _deleteHotelCommand;
        public ICommand _updateHotelCommand;

        public Hotel NewHotel
        {
            get { return _newHotel; }
            set { _newHotel = value; OnPropertyChanged(); }
        }

        public ICommand CreateHotelCommand
        {
            get { return _createHotelCommand; }
            set { _createHotelCommand = value; }
        }
        public ICommand DeleteHotelCommand
        {
            get { return _deleteHotelCommand; }
            set { _deleteHotelCommand = value; }
        }

        public ICommand UpdateHotelCommand
        {
            get { return _updateHotelCommand; }
            set { _updateHotelCommand = value; }
        }

        public static Hotel SelectedHotel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}