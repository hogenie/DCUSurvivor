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
        // 저장된 플레이어 정보 로드하기
        LoadPlayerData();

        // 리더보드 UI 업데이트하기
        UpdateLeaderboard();
    }

    public void SavePlayerName()
    {
        // InputField에 입력된 이름을 가져와서 플레이어 정보에 저장합니다.
        string playerName = nameInputField.text;
        Player player = new Player();
        player.name = playerName;
        player.score = GameManager.instance.kill;

        // 플레이어 정보 리스트에 추가합니다.
        players.Add(player);

        // 플레이어 정보를 PlayerPref에 저장합니다.
        SavePlayerData();

        // 리더보드 UI 업데이트하기
        UpdateLeaderboard();
    }

    private void UpdateLeaderboard()
    {
        // 플레이어 정보를 점수순으로 정렬합니다.
        players.Sort((a, b) => b.score.CompareTo(a.score));

        // 리더보드 UI에 플레이어 이름과 점수를 표시합니다.
        string leaderboardString = "";
        for (int i = 0; i < players.Count; i++)
        {
            leaderboardString += string.Format("{0}. {1}: {2}\n", i + 1, players[i].name, players[i].score);
        }
        leaderboardText.text = leaderboardString;
    }

    private void SavePlayerData()
    {
        // 플레이어 정보를 PlayerPref에 저장합니다.
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
        // 저장된 플레이어 정보를 PlayerPref에서 로드합니다.
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
