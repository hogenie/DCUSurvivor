using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Text leaderboardText;

    private const string playerNameKey = "PlayerName";
    private const string playerScoreKey = "PlayerScore";
    private class Player
    {
        public string name;
        public int score;
    }
    private List<Player> players = new List<Player>();

    private void Start()
    {
        // ����� �÷��̾� ���� �ε��ϱ�
        LoadPlayerData();

        // �������� UI ������Ʈ�ϱ�
        UpdateLeaderboard();
    }

    public void SavePlayerName()
    {
        // InputField�� �Էµ� �̸��� �����ͼ� �÷��̾� ������ �����մϴ�.
        string playerName = nameInputField.text;
        Player player = new Player();
        player.name = playerName;
        player.score = GameManager.instance.kill;

        // �÷��̾� ���� ����Ʈ�� �߰��մϴ�.
        players.Add(player);

        // �÷��̾� ������ PlayerPref�� �����մϴ�.
        SavePlayerData();

        // �������� UI ������Ʈ�ϱ�
        UpdateLeaderboard();
    }

    private void UpdateLeaderboard()
    {
        // �÷��̾� ������ ���������� �����մϴ�.
        players.Sort((a, b) => b.score.CompareTo(a.score));

        // �������� UI�� �÷��̾� �̸��� ������ ǥ���մϴ�.
        string leaderboardString = "";
        for (int i = 0; i < players.Count; i++)
        {
            leaderboardString += string.Format("{0}. {1}: {2}\n", i + 1, players[i].name, players[i].score);
        }
        leaderboardText.text = leaderboardString;
    }

    private void SavePlayerData()
    {
        // �÷��̾� ������ PlayerPref�� �����մϴ�.
        PlayerPrefs.SetInt(playerScoreKey, players.Count);
        for (int i = 0; i < players.Count; i++)
        {
            PlayerPrefs.SetString(playerNameKey + i, players[i].name);
            PlayerPrefs.SetInt(playerScoreKey + i, players[i].score);
        }
        PlayerPrefs.Save();
    }

    private void LoadPlayerData()
    {
        // ����� �÷��̾� ������ PlayerPref���� �ε��մϴ�.
        players.Clear();
        int playerCount = PlayerPrefs.GetInt(playerScoreKey);
        for (int i = 0; i < playerCount; i++)
        {
            string playerName = PlayerPrefs.GetString(playerNameKey + i);
            int playerScore = PlayerPrefs.GetInt(playerScoreKey + i);

            Player player = new Player();
            player.name = playerName;
            player.score = playerScore;

            players.Add(player);
        }
    }
}
