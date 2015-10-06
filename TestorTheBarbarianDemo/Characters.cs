using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestorTheBarbarianDemo
{
    public class Player
    {
        private string _name;
        private iCharacter _character;


        public Player(string name)
        {
            _name = name;
            Party = new List<iCharacter>();

        }

        public Player(string name, iCharacter character)
        {
            _name = name;
            _character = character;
            Party = new List<iCharacter>();
            Party.Add(_character);
        }

        public iCharacter Character { get; }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public IList<iCharacter> Party { get; set; }
    }

    public class TestorTheBarbarian : iCharacter
    {
        private string _name;
        private string _activeWeapon;
        private List<string> _attacks;
        private List<string> _weapons;

        public TestorTheBarbarian()
        {
            _name = "Testor The Mighty Barbarian";

            _attacks = new List<string>() { "Clobber" };

            _weapons = new List<string>() { "Fists Of Fury" };
            Health = 100;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Health { get; set; }

        public IEnumerable<string> Attacks
        {
            get
            {
                return _attacks;
            }
        }

        public IEnumerable<string> Weapons
        {
            get
            {
                return _weapons;
            }
        }

        public string BattleCry
        {
            get
            {
                return "";
            }
        }

        public string ActiveWeapon
        {
            get
            {
                return _activeWeapon;
            }
        }

        public void EquipWeapon(string weapon)
        {
            if (_weapons.Contains(weapon, StringComparer.OrdinalIgnoreCase))
            {
                _activeWeapon = weapon;
            }
            else
            {

                throw new ArgumentException("Weapon Not Available /{weapon}", "weapon");
            }
        }

        public void AddAttack(string attack)
        {
            if (!_attacks.Contains(attack))
            {
                _attacks.Add(attack);
            }
        }

        public void AddWeapon(string weapon)
        {
            if (!_weapons.Contains(weapon))
            {
                _weapons.Add(weapon);
            }
        }

        public void Rest(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
    }

    public class MasterCodo : iCharacter
    {
        private string _name;
        private string _activeWeapon;
        private List<string> _attacks;
        private List<string> _weapons;

        public MasterCodo()
        {
            _name = "Master Codo";

            _attacks = new List<string>() { "Sling" };

            _weapons = new List<string>() { "Fiery Fingers" };

            Health = 100;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Health { get; set; }

        public IEnumerable<string> Attacks
        {
            get
            {
                return _attacks;
            }
        }

        public IEnumerable<string> Weapons
        {
            get
            {
                return _weapons;
            }
        }

        public string BattleCry
        {
            get
            {
                return "";
            }
        }

        public string ActiveWeapon
        {
            get
            {
                return _activeWeapon;
            }
        }

        public void EquipWeapon(string weapon)
        {
            if (_weapons.Contains(weapon, StringComparer.OrdinalIgnoreCase))
            {
                _activeWeapon = weapon;
            }
            else
            {

                throw new ArgumentException("Weapon Not Available /{weapon}", "weapon");
            }
        }

        public void AddAttack(string attack)
        {
            if (!_attacks.Contains(attack))
            {
                _attacks.Add(attack);
            }
        }

        public void AddWeapon(string weapon)
        {
            if (!_weapons.Contains(weapon))
            {
                _weapons.Add(weapon);
            }
        }

        public void Rest(int ms)
        {
            throw new NotImplementedException();
        }
    }

  
    public class Enemy
    {
        public string Name { get; set; }

        public int Strength { get; set; }

        public int Health { get; set; }

    }

    public interface iCharacter
    {
        string Name { get; }

        string BattleCry { get; }

        int Health { get; set; }

        IEnumerable<string> Attacks { get; }

        IEnumerable<string> Weapons { get; }

        void EquipWeapon(string weapon);

        void AddAttack(string attack);

        void AddWeapon(string weapon);

        void Rest(int ms);
    }

}
