using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GUI
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableObject()
        {
            Messages.CollectionChanged += Messages_CollectionChanged;
        }

        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();

        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Messages");
        }

        private string messageContent = "";
        public string MessageContent
        {
            get
            {
                return messageContent;
            }
            set
            {
                messageContent = value;
                OnPropertyChanged("MessageContent");
            }
        }

        #region Binding
        private float sliderOneWay = 0.0f;
        public float SliderOneWay
        {
            get
            {
                return sliderOneWay;
            }
            set
            {
                if (value >= 0.0 && value <= 100.0)
                {
                    sliderOneWay = value;
                    OnPropertyChanged("SliderOneWay");
                }
            }
        }
        private float sliderOneWayToSource = 0.0f;
        public float SliderOneWayToSource
        {
            get
            {
                return sliderOneWayToSource;
            }
            set
            {
                if (value >= 0.0 && value <= 100.0)
                {
                    sliderOneWayToSource = value;
                    OnPropertyChanged("SliderOneWayToSource");
                }
            }
        }
        private float sliderTwoWay = 0.0f;
        public float SliderTwoWay
        {
            get
            {
                return sliderTwoWay;
            }
            set
            {
                if (value >= 0.0 && value <= 100.0)
                {
                    sliderTwoWay = value;
                    OnPropertyChanged("SliderTwoWay");
                }
            }
        }

        #endregion

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}