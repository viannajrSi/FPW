using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Processamento
{
    public class NotifyPropertyBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Após Alterar a Propriedade
        /// </summary>
        /// <param name="info"></param>
        protected virtual void OnPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        /// <summary>
        /// Alterando a Propriedade
        /// </summary>
        /// <param name="info"></param>
        protected virtual void OnPropertyChanging(string info)
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, new PropertyChangingEventArgs(info));
            }
        }
    }
}
