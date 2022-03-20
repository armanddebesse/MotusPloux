using MotusPloux.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MotusPloux.ViewModels
{
    public class PlayingViewModel : BaseViewModel
    {
        private readonly List<WordViewModel> _wordList;

        private WordViewModel _word;

        public WordViewModel Word
        {
            get { return _word; }
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
            }
        }

        public PlayingViewModel()
        {
            _wordList = new List<WordViewModel>();
            GetWordsFromDb();
        }

        private async void GetWordsFromDb()
        {
            List<Word> wordList = new List<Word>();
            wordList.AddRange(await App.Database.GetWordsAsync());
            foreach (Word word in wordList)
            {
                _wordList.Add(new WordViewModel(word));
            }
            UpdateWord();
        }

        private void UpdateWord()
        {
            Random random = new Random();
            Word = _wordList[random.Next(_wordList.Count)];
        }
    }
}
