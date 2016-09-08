using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace GG.CharacterSystem
{
    public class BaseCharacter
    {
        #region variables
        //General data
        private string _firstName;
        private string _lastName;
        private bool _isMale;
        private int _age;
        private bool _isAgeless;
        private int _level;
        private int _race;
        private int _exp;
        private int _expToLevel;
       // private int _personality;
        //Stats and vitals
        private Vital[] _vitals;
        private BaseStats[] _coreStats;
        //Classes
        private int _curJob;
        private List<Job> _jobs;
        //Spells

        //Passives

        //
        #endregion
        #region Setters and getters
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public bool isMale
        {
            get { return _isMale; }
            set { _isMale = value; }
        }
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }
        public int race
        {
            get { return _race; }
            set { _race = value; }
        }
        public int curJob
        {
            set { _curJob = value; }
            get { return _curJob; }
        }
        public List<Job> job
        {
            get { return _jobs; }
            set { _jobs = value; }
        }
        //Sets and gets for arrays
        public Vital GetVitals(int index)
        {
            return _vitals[index]; 
        }        
        public BaseStats GetStats(int index)
        {
            return _coreStats[index];
        }
        public int expToLevel
        {
            get { return _expToLevel; }
            set { _expToLevel = value; }
        }
        public int Exp
        {
            get
            {
                return _exp;
            }

            set
            {
                _exp = value;
            }
        }
        #endregion
        #region Constructors
        public BaseCharacter()
        {
            
            _race = 0;
            RandomGender();
            RandomFirstName();
            RandomLastName();
            RandomAge();
            _exp = 0;
            _expToLevel = 1000;
            _isAgeless = false;
            _coreStats = new BaseStats[Enum.GetNames(typeof(StatNames)).Length];
            for (int i = 0; i < _coreStats.Length; i++)
            {

                _coreStats[i] = new BaseStats();
                _coreStats[i].name = Enum.GetName(typeof(StatNames), i);

            }
            RandomStatValues();
            RacialAdjustments();
            _vitals = new Vital[Enum.GetNames(typeof(VitalNames)).Length];
            for (int i = 0; i < _vitals.Length; i++)
            {
                _vitals[i] = new Vital();
                _vitals[i].name = Enum.GetName(typeof(VitalNames), i);

            }
            UpdateVitals();
            _curJob = 0;
            _jobs = new List<Job>();
        }
        #endregion
        #region Functions
        public void RandomAge()
        {
            Random rand = new Random();
            switch (_race) {
                //elf
                case 1:
                    _age = rand.Next(105, 150);
                    break;
                //dwalf
                case 2:
                    _age = rand.Next(75, 115);
                    break;
                //Halfling
                case 3:
                    _age = rand.Next(20, 28);
                    break;
                //Demonkin
                case 4:
                    _age = rand.Next(40, 55);
                    break;
                //Angelkin
                case 5:
                    _age = rand.Next(40, 50);
                    break;
                //human
                default:
                    _age = rand.Next(16, 24);
                    break;
            }
        }
        public int RandomFirstName()
        {
            Random rand = new Random();
            int naming = 0;
            if (isMale)
            {
                naming = rand.Next(Enum.GetNames(typeof(MaleNames)).Length);
                _firstName = Enum.GetName(typeof(MaleNames), naming);
                return naming;
            }
            else {
                naming = rand.Next(Enum.GetNames(typeof(FemaleNames)).Length);
                _firstName = Enum.GetName(typeof(FemaleNames), naming);
                return naming;
            }
        }
        public int RandomLastName()
        {
            Random rand = new Random();
            int naming = rand.Next(Enum.GetNames(typeof(LastName)).Length);
            _lastName = Enum.GetName(typeof(LastName), naming);
            return naming;

        }
        public void RandomGender()
        {
            Random rand = new Random();
            int check = rand.Next(100);
            

            int lastname = rand.Next(Enum.GetNames(typeof(LastName)).Length);
            if (check < 50)
            {
                _isMale = false;
                int naming = rand.Next(Enum.GetNames(typeof(FemaleNames)).Length);
                _firstName = Enum.GetName(typeof(FemaleNames), naming);
            }
            else
            {
                _isMale = true;
                int naming = rand.Next(Enum.GetNames(typeof(MaleNames)).Length);
                _firstName = Enum.GetName(typeof(MaleNames), naming);
            }
            _lastName = Enum.GetName(typeof(LastName), lastname);
        }
        public void RandomStatValues()
        {
            Random rand = new Random();

            for (int i = 0; i < _coreStats.Length; i++) {
                _coreStats[i].baseValue = rand.Next(12, 18);
                _coreStats[i].SetFullValue();
            }
        }
        public void RacialAdjustments()
        {
            switch (_race)
            {
                //Elf
                case 1:
                    _coreStats[1].baseValue++;
                    _coreStats[1].SetFullValue();
                    _coreStats[2].baseValue--;
                    _coreStats[2].SetFullValue();

                    break;
                //Dwalf
                case 2:
                    _coreStats[2].baseValue++;
                    _coreStats[2].SetFullValue();
                    _coreStats[4].baseValue--;
                    _coreStats[4].SetFullValue();
                    break;
                //Halfling
                case 3:
                    _coreStats[0].baseValue--;
                    _coreStats[0].SetFullValue();
                    _coreStats[1].baseValue++;
                    _coreStats[1].SetFullValue();
                    break;
                //Demonkin
                case 4:
                    _coreStats[3].baseValue++;
                    _coreStats[3].SetFullValue();
                    _coreStats[5].baseValue--;
                    _coreStats[5].SetFullValue();
                    break;
                //Angelkin
                case 5:
                    _coreStats[4].baseValue++;
                    _coreStats[4].SetFullValue();
                    _coreStats[5].baseValue--;
                    _coreStats[5].SetFullValue();
                    break;
                //Human
                default:
                    _coreStats[0].baseValue++;
                    _coreStats[0].SetFullValue();
                    _coreStats[4].baseValue--;
                    _coreStats[4].SetFullValue();
                    break;
            }
        }
        public void GrowOld()
        {
            if (!_isAgeless)
            {
                _age++;
            }
        }
        public void AddExp(int Exp)
        {
            _exp += Exp;
            if(_exp >= _expToLevel)
            {
                levelUp();
            }
            if(_jobs.ElementAt(_curJob).exp >= _jobs.ElementAt(_curJob).lvlUpReq)
            {
                _jobs.ElementAt(_curJob).LevelUp();
            }
        }
        public void UpdateVitals()
        {
            _vitals[0].UpdateStatEffect(_coreStats[2].fullValue);
            _vitals[1].UpdateStatEffect(_coreStats[4].fullValue);
            _vitals[2].UpdateStatEffect(_coreStats[1].fullValue);
            for (int i = 0; i < 3; i++)
            {
                _vitals[i].UpdateVital();
                _vitals[i].curValue = _vitals[i].fullValue;
            }
        }
        public void AddToCurVitals(int index, int val)
        {
            _vitals[index].curValue += val;
            if(_vitals[index].curValue > _vitals[index].fullValue)
            {
                _vitals[index].curValue = _vitals[index].fullValue;
            }
            if(_vitals[index].curValue < 0)
            {
                _vitals[index].curValue = 0;
            }
        }
        public void AddNewJob(Job newJob)
        {
            newJob.ActivateJob();
            _jobs.Add(newJob);
        }
        public void UnlockClass()
        {

        }
        public void levelUp() {
            Job temp = _jobs.ElementAt(_curJob);
            _level++;
            _exp -= _expToLevel;
            for(int i = 0; i < temp.statEvolve.Length; i++)
            {
                _coreStats[i].baseValue += temp.statEvolve[i];
                _coreStats[i].SetFullValue();
            }
        }
        #endregion
    }
    #region Enums
    public enum MaleNames
    {
        John,
        Jeffory,
        Leeroy,
        Alexander,
        Gil,
        Cid,
        Donald,
        Claud,
        Vincent,
        Lucient,
        Nero,
        Raja,
        Gary,
        Jesse,
        Joshua,
        Timothy
    };
    public enum FemaleNames
    {
        Seishin,
        Leona,
        Mary,
        Jane,
        Luca,
        Elise,
        Fiona,
        Tegan,
        Jessica,
        Elizabeth

    };
    public enum LastName
    {
        Elysmire,
        Ravensmith,
        Redlum,
        Hardgrave,
        Smith,
        Crowfard
    };
    public enum RaceNames
    {
        Human,              //Hyman
        Elf,                //Elev
        Dwalf,              //Dwelm
        Halfing,            //Handren
        Demonfolk,          //Daemonfolk
        Angelfolk           //

    };
    #endregion
}