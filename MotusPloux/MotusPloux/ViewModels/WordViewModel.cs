using MotusPloux.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MotusPloux.ViewModels
{
    public class WordViewModel : BaseViewModel
    {
        private readonly Word _word;

        public ObservableCollection<string> CharList { get; set; }

        public WordViewModel(Word word)
        {
            _word = word;

            CharList = new ObservableCollection<string>();

            foreach (char character in _word.Text)
            {
                CharList.Add(character.ToString());
            }
        }
    }
}
