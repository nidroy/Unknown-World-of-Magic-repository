using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Dictionary
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        // заполнение словаря
        public void FillingDictionary()
        {
            // словарь локаций
            dictionary.Add("SetInitialLocation", "null");
            dictionary.Add("SetNextLocation", "null");
            dictionary.Add("SetPreviousLocation", "null");
            // словарь характеристик
            dictionary.Add("IncreaseStrength", "null");
            dictionary.Add("IncreaseAgility", "null");
            dictionary.Add("IncreaseIntelligence", "null");
            // соварь получения атрибутов персонажа
            dictionary.Add("GetWarriorAttributes", "null");
            dictionary.Add("GetAssassinAttributes", "null");
            dictionary.Add("GetWizardAttributes", "null");
            dictionary.Add("GetBanditAttributes", "null");
            dictionary.Add("GetLeshiiAttributes", "null");
            // словарь игрока
            dictionary.Add("SetPlayerName", "null");
            dictionary.Add("PlayerAttack", "null");
            dictionary.Add("RestoringHealthPoints", "null");
            dictionary.Add("RestoringActionPoints", "null");
            dictionary.Add("IncreaseExperiencePoints", "null");
            dictionary.Add("ResetExperiencePoints", "null");
            dictionary.Add("IncreaseLevel", "null");
            dictionary.Add("IncreaseGold", "null");
            // словарь врага
            dictionary.Add("EnemyAttack", "null");
        }

        // перезапись элемента словаря
        public void OverwritingDictionaryElement(string key, string value)
        {
            dictionary[key] = value;
        }

    }
}
