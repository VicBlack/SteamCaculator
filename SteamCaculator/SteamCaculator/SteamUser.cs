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
        public int CurrentLevel { get { return _CurrentLevel; } set { if (_CurrentLevel == value) return; _CurrentLevel = value; _CurrentExp = getExpfromLevel(_CurrentLevel); OnPropertyChanged(nameof(CurrentLevel)); OnPropertyChanged(nameof(CurrentExp)); } }
        private int _CurrentLevel;

        public int CurrentExp { get { return _CurrentExp; } set { if (_CurrentExp == value) return; _CurrentExp = value; _CurrentLevel = getLevelfromExp(_CurrentExp); OnPropertyChanged(nameof(CurrentLevel)); OnPropertyChanged(nameof(CurrentExp)); } }
        private int _CurrentExp;

        public int TargetLevel { get { return _TargetLevel; } set { if (_TargetLevel == value) return; _TargetLevel = value; OnPropertyChanged(nameof(TargetLevel)); } }
        private int _TargetLevel;

        public int TargetFriendsLimit { get { return _TargetFriendsLimit; } set { if (_TargetFriendsLimit == value) return; _TargetFriendsLimit = value; OnPropertyChanged(nameof(TargetFriendsLimit)); } }
        private int _TargetFriendsLimit;

        public int TargetDisplayCaseLimit { get { return _TargetDisplayCaseLimit; } set { if (_TargetDisplayCaseLimit == value) return; _TargetDisplayCaseLimit = value; OnPropertyChanged(nameof(TargetDisplayCaseLimit)); } }
        private int _TargetDisplayCaseLimit;

        public int RequiredExp { get { return _RequiredExp; } set { if (_RequiredExp == value) return; _RequiredExp = value; OnPropertyChanged(nameof(RequiredExp)); } }
        private int _RequiredExp;

        public int RequiredCards { get { return _RequiredCards; } set { if (_RequiredCards == value) return; _RequiredCards = value; OnPropertyChanged(nameof(RequiredCards)); } }
        private int _RequiredCards;

        public int CurrentCards { get { return _CurrentCards; } set { if (_CurrentCards == value) return; _CurrentCards = value; OnPropertyChanged(nameof(CurrentCards)); } }
        private int _CurrentCards;

        public int ReachLevel { get { return _ReachLevel; } set { if (_ReachLevel == value) return; _ReachLevel = value; OnPropertyChanged(nameof(ReachLevel)); } }
        private int _ReachLevel;

        public int ReachExp { get { return _ReachExp; } set { if (_ReachExp == value) return; _ReachExp = value; OnPropertyChanged(nameof(ReachExp)); } }
        private int _ReachExp;

        public int ReachFriendsLimit { get { return _ReachFriendsLimit; } set { if (_ReachFriendsLimit == value) return; _ReachFriendsLimit = value; OnPropertyChanged(nameof(ReachFriendsLimit)); } }
        private int _ReachFriendsLimit;

        public int ReachDisplayCaseLimit { get { return _ReachDisplayCaseLimit; } set { if (_ReachDisplayCaseLimit == value) return; _ReachDisplayCaseLimit = value; OnPropertyChanged(nameof(ReachDisplayCaseLimit)); } }
        private int _ReachDisplayCaseLimit;
        #endregion

        #region 外部方法
        
        #endregion

        #region 内部方法
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
        private int getLevelfromCard(int cards)
        {

            return 0;
        }
        private int getExpfromCard(int cards)
        {
            return 0;
        }
        private int getFriendsLimitfromCard(int cards)
        {
            return 0;
        }
        private int getDisplayCaseLimitfromCard(int cards)
        {
            return 0;
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
