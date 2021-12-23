using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScrollViewAdapter : MonoBehaviour
{
    public RectTransform playerPrefab;
    public RectTransform content;

    public Player player;
    public Enemy enemy;
    public Characteristics characteristics;
    public Location location;

    public Animator gameAnim; // анимации игры
    public Sprite[] Icon;

    public Dictionary<string, Sprite> dictionary = new Dictionary<string, Sprite>();

    public void UpdateItems()
    {
        Server server = new Server();
        string[] players = server.SendingMessage("GetPlayers").Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
        if (players[0] != "NULL")
        {
            FillingDictionary();
            StartCoroutine(GetItems(players, results => OnReceivedModels(results)));
        }
    }

    private void FillingDictionary()
    {
        dictionary.Clear();

        dictionary.Add("Warrior", Icon[0]);
        dictionary.Add("Assassin", Icon[1]);
        dictionary.Add("Wizard", Icon[2]);
        dictionary.Add("Bandit", Icon[3]);
        dictionary.Add("Leshii", Icon[4]);
    }

    void OnReceivedModels(ItemModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(playerPrefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, ItemModel model)
    {
        ItemView view = new ItemView(viewGameObject.transform);
        view.playerNumber.text = model.playerNumber;
        view.playerName.text = model.playerName;
        view.playerClass.text = model.playerClass;
        view.playerLevel.text = model.playerLevel;
        view.playerGold.text = model.playerGold;
        view.playerSelectionButton.onClick.AddListener(
            () =>
            {
                gameAnim.SetBool("isShowContinue", false);
                Server server = new Server();
                string[] attribute = server.SendingMessage("GetAttributes_" + view.playerName.text).Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                SetAttributes(attribute);
                location.SetLocationBoundaries("Glade", "Forest");
                player.SetAbilityRestoring(true);
            }
        );
    }

    private void SetAttributes(string[] attribute)
    {
        player.SetCharacterName(attribute[0]);
        player.SetPlayerClass(attribute[1]);
        player.SetMaximumCharacterHealthPoints(int.Parse(attribute[10]) * 10);
        player.SetCharacterHealthPoints(int.Parse(attribute[2]));
        player.SetMaximumPlayerActionPoints(int.Parse(attribute[12]) * 10);
        player.SetPlayerActionPoints(int.Parse(attribute[3]));
        player.SetMaximumPlayerExperiencePoints(100 + 100 * int.Parse(attribute[6]));
        player.SetPlayerExperiencePoints(int.Parse(attribute[4]));
        player.SetPlayerSkillPoints(int.Parse(attribute[5]));
        player.SetCharacterLevel(int.Parse(attribute[6]));
        player.SetPlayerGold(int.Parse(attribute[7]));
        player.SetCharacterIcon(dictionary[player.playerClass]);

        characteristics.SetStrength(int.Parse(attribute[10]));
        characteristics.SetAgility(int.Parse(attribute[11]));
        characteristics.SetIntelligence(int.Parse(attribute[12]));

        enemy.SetCharacterName(attribute[13]);
        enemy.SetMaximumCharacterHealthPoints(int.Parse(attribute[14]));
        enemy.SetCharacterHealthPoints(int.Parse(attribute[14]));
        enemy.SetCharacterLevel(int.Parse(attribute[16]));
        enemy.SetCharacterIcon(dictionary[enemy.characterName.text]);

        location.SetLocationName(attribute[21]);
        location.SetLocationDescription(attribute[22]);
    }

    IEnumerator GetItems(string[] players, System.Action<ItemModel[]> callback)
    {
        yield return new WaitForSeconds(0.1f);
        var results = new ItemModel[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            string[] attribute = players[i].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            results[i] = new ItemModel();
            results[i].playerNumber = (i + 1).ToString();
            results[i].playerName = attribute[0];
            results[i].playerClass = attribute[1];
            results[i].playerLevel = attribute[2];
            results[i].playerGold = attribute[3];
        }

        callback(results);
    }

    public class ItemView
    {
        public Text playerNumber;
        public Text playerName;
        public Text playerClass;
        public Text playerLevel;
        public Text playerGold;
        public Button playerSelectionButton;


        public ItemView(Transform rootView)
        {
            playerNumber = rootView.Find("Number").GetComponent<Text>();
            playerName = rootView.Find("Name").GetComponent<Text>();
            playerClass = rootView.Find("Class").GetComponent<Text>();
            playerLevel = rootView.Find("Level").GetComponent<Text>();
            playerGold = rootView.Find("Gold").GetComponent<Text>();
            playerSelectionButton = rootView.Find("Frame").GetComponent<Button>();
        }
    }

    public class ItemModel
    {
        public string playerNumber;
        public string playerName;
        public string playerClass;
        public string playerLevel;
        public string playerGold;
    }
}
