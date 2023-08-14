using System;
using System.Xml.Linq;
using System.Windows.Input;
using Ara.MeritViewer.Data;
using Ara.MeritViewer.Model;
using Ara.MeritViewer.Command;

namespace Ara.MeritViewer.ViewModel
	{
	class WindowMainViewModel : ViewModelBase
		{
		#region Fields
		
		private Empires currentempire;
		private XElement data;
		private RelayCommand changeempire;

		#endregion

		#region Constructors
		
		public WindowMainViewModel()
			{
			currentempire = Empires.NotSet;
			data = ApplicationDataLayer.DataXML;
			}

		#endregion

		#region Properties

		public Empires CurrentEmpire
			{
			get
				{
				return currentempire;
				}
			set
				{
				currentempire = value;
				OnPropertyChanged("CurrentEmpire");
				}
			}

		public ICommand ChangeEmpireCommand
			{
			get
				{
				if (changeempire == null)
					changeempire = new RelayCommand(param => ChangeEmpire(currentempire));
				return changeempire;
				}
		  }

		#endregion
		
		#region Methods

		private void ChangeEmpire(Empires newempire)
			{
			currentempire = newempire;

			}

		private void FilterEmpireData(Empires newempire)
			{

			}

		#endregion
		}
	}
