using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCaculator
{
    class SteamUser:INotifyPropertyChanged
    {
        #region 成员
        public int CurrentLevel { get { return _CurrentLevel; } set { if (_CurrentLevel == value) return; _CurrentLevel = Math.Max(value,0); _CurrentExp = getExpfromLevel(_CurrentLevel); OnPropertyChanged(nameof(CurrentLevel)); OnPropertyChanged(nameof(CurrentExp)); updateSomething(); getSomethingfromCard(); } }
        private int _CurrentLevel;

        public int CurrentExp { get { return _CurrentExp; } set { if (_CurrentExp == value) return; _CurrentExp = Math.Max(value,0); _CurrentLevel = getLevelfromExp(_CurrentExp); OnPropertyChanged(nameof(CurrentExp)); OnPropertyChanged(nameof(CurrentLevel)); updateSomething(); getSomethingfromCard(); } }
        private int _CurrentExp;

        public int CurrentFriendsLimit { get { return _CurrentFriendsLimit; } }
        private int _CurrentFriendsLimit;

        public int CurrentDisplayCaseLimit { get { return _CurrentDisplayCaseLimit; } }
        private int _CurrentDisplayCaseLimit;

        public int TargetLevel { get { return _TargetLevel; } set { /*if (value < _CurrentLevel) { _TargetLevel = _CurrentLevel; return; }*/ if (_TargetLevel == value) return; _TargetLevel = Math.Max(value, 0); OnPropertyChanged(nameof(TargetLevel)); getSomethingfromLevel(); } }
        private int _TargetLevel;

        public int TargetFriendsLimit { get { return _TargetFriendsLimit; } set { /*if (value < _CurrentFriendsLimit) { _TargetFriendsLimit = _CurrentFriendsLimit; return; }*/ if (_TargetFriendsLimit == value) return; _TargetFriendsLimit = Math.Max(value, 0); OnPropertyChanged(nameof(TargetFriendsLimit)); getSomethingfromFriendsLimit(); } }
        private int _TargetFriendsLimit;

        public int TargetDisplayCaseLimit { get { return _TargetDisplayCaseLimit; } set { /*if (value < _CurrentDisplayCaseLimit) { _TargetDisplayCaseLimit = _CurrentDisplayCaseLimit; return; }*/ if (_TargetDisplayCaseLimit == value) return; _TargetDisplayCaseLimit = Math.Max(value, 0); OnPropertyChanged(nameof(TargetDisplayCaseLimit)); getSomethingfromDisplayCaseLimit(); } }
        private int _TargetDisplayCaseLimit;

        public int RequiredExp { get { return _RequiredExp; } }
        private int _RequiredExp;

        public int RequiredCards { get { return _RequiredCards; } }
        private int _RequiredCards;

        public int CurrentCards { get { return _CurrentCards; } set { if (_CurrentCards == value) return; _CurrentCards = Math.Max(value, 0); OnPropertyChanged(nameof(CurrentCards)); getSomethingfromCard();} }
        private int _CurrentCards;

        public int ReachLevel { get { return _ReachLevel; } }
        private int _ReachLevel;

        public int ReachNextExp { get { return _ReachNextExp; } }
        private int _ReachNextExp;

        public int ReachFriendsLimit { get { return _ReachFriendsLimit; } }
        private int _ReachFriendsLimit;

        public int ReachDisplayCaseLimit { get { return _ReachDisplayCaseLimit; } }
        private int _ReachDisplayCaseLimit;
        #endregion

        #region 方法
        public SteamUser()
        {
            updateSomething();
            getSomethingfromCard();
        }
        private int getLevelfromExp(int Exp)
        {
            Exp = Exp / 100;
            int Level = 0;
            int LevelExp = 0;
            while(Exp > LevelExp)
            {
                Level ++;
                LevelExp += ((Level / 10) + 1);
            }
            return Level;
        }
        private int getExpfromLevel(int Level)
        {
            int StepLevel = 0;
            int LevelExp = 0;
            while (Level > StepLevel)
            {                
                LevelExp += ((StepLevel / 10) + 1) * 100;
                StepLevel++;
            }
            return LevelExp;
        }
        private void updateSomething()
        {
            _CurrentFriendsLimit = 250 + _CurrentLevel * 5;
            _CurrentDisplayCaseLimit = Math.Min(_CurrentLevel / 10, 13);
            OnPropertyChanged(nameof(CurrentFriendsLimit));
            OnPropertyChanged(nameof(CurrentDisplayCaseLimit));
        }
        private void getSomethingfromCard()
        {
            int Exp = _CurrentExp;
            Exp += _CurrentCards * 100;
            _ReachLevel = getLevelfromExp(Exp);
            _ReachNextExp = getExpfromLevel(_ReachLevel + 1) - Exp;
            _ReachFriendsLimit = 250 + _ReachLevel * 5;
            _ReachDisplayCaseLimit = Math.Min(_ReachLevel / 10, 13);
            OnPropertyChanged(nameof(ReachNextExp));
            OnPropertyChanged(nameof(ReachLevel));
            OnPropertyChanged(nameof(ReachFriendsLimit));
            OnPropertyChanged(nameof(ReachDisplayCaseLimit));
        }
        private void getSomethingfromLevel()
        {
            if(_TargetLevel < _CurrentLevel)
            {
                _TargetFriendsLimit = _CurrentFriendsLimit;
                _TargetDisplayCaseLimit = _CurrentDisplayCaseLimit;
            }
            else
            {
                _TargetFriendsLimit = 250 + _TargetLevel * 5;
                _TargetDisplayCaseLimit = Math.Min(_TargetLevel / 10, 13);
            }            
            OnPropertyChanged(nameof(TargetFriendsLimit));
            OnPropertyChanged(nameof(TargetDisplayCaseLimit));
            getSomethingfromTarget();
        }
        private void getSomethingfromFriendsLimit()
        {
            if(_TargetFriendsLimit < _CurrentFriendsLimit)
            {
                _TargetLevel = _CurrentLevel;
                _TargetDisplayCaseLimit = _CurrentDisplayCaseLimit;
            }
            else
            {
                _TargetLevel = _TargetFriendsLimit % 5 == 0 ? (_TargetFriendsLimit - 250) / 5 : (_TargetFriendsLimit - 250) / 5 + 1;
                _TargetDisplayCaseLimit = Math.Min(_TargetLevel / 10, 13);
            }            
            OnPropertyChanged(nameof(TargetLevel));
            OnPropertyChanged(nameof(TargetDisplayCaseLimit));
            getSomethingfromTarget();
        }
        private void getSomethingfromDisplayCaseLimit()
        {
            if(_TargetDisplayCaseLimit < _CurrentDisplayCaseLimit)
            {
                _TargetLevel = _CurrentLevel;
                _TargetFriendsLimit = _CurrentFriendsLimit;
            }
            else
            {
                _TargetLevel = Math.Min(_TargetDisplayCaseLimit, 13) * 10;
                _TargetFriendsLimit = 250 + _TargetLevel * 5;
            }            
            OnPropertyChanged(nameof(TargetLevel));
            OnPropertyChanged(nameof(TargetFriendsLimit));
            getSomethingfromTarget();
        }
        private void getSomethingfromTarget()
        {
            if (_TargetLevel < _CurrentLevel)
            {
                _RequiredExp = 0;
                _RequiredCards = 0;
            }
            else
            {
                int Exp = getExpfromLevel(_TargetLevel);
                _RequiredExp = Exp - CurrentExp;
                _RequiredCards = _RequiredExp % 100 == 0 ? _RequiredExp / 100 : _RequiredExp / 100 + 1;
            }            
            OnPropertyChanged(nameof(RequiredExp));
            OnPropertyChanged(nameof(RequiredCards));
        }
        #endregion

        #region INotifyPropertyChanged接口便利实现
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
