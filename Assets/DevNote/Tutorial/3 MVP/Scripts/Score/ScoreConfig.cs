using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DevNote.Tutorial.MVP
{
    // ����������� � ������ Configs/ , �������� ��� ��������� Config
    [CreateAssetMenu(menuName = "Configs/Score", fileName = "Score")]
    public class ScoreConfig : ScriptableObject
    {
        // ��������� ��������� ������ ������������ � �������� ��� ����������� ������
        // ������, ��������� ����� ����� ��������� � ��� �� �������, ���� ������� �����.
        [Serializable] private struct LevelUpData
        {
            public int requiredScore;
            public int scorePerClick;
        }


        // ��� ���� � ������� ������ ���� �������� �� ������, �� ������� - ��� ���������!
        // ���� ��� ������ - ��������� ���������� Prefab
        [field: SerializeField] public ScoreWindowView ScoreWindowPrefab { get; private set; }

        // �� ������ ����� ����� � �������, ���������� ��� �������������� �� ����������,
        // �� ������ ��������� ������ ��������� ������ �� ����� �������, �������������� ����
        [SerializeField] private List<LevelUpData> _levelUps;


        public int GetScorePerClick(int currentScore)
        {
            foreach (var levelUp in _levelUps)
            {
                if (currentScore < levelUp.requiredScore)
                    return levelUp.scorePerClick;
            }

            return _levelUps.Last().scorePerClick;
        }


        public int GetLevel(int currentScore)
        {
            for (int i = 0; i < _levelUps.Count; i++)
            {
                if (currentScore < _levelUps[i].requiredScore)
                    return i + 1;
            }

            return _levelUps.Count;
        }

        public int GetScoreRequireForNextLevel(int currentScore)
        {
            foreach (var levelUp in _levelUps)
            {
                if (currentScore < levelUp.requiredScore)
                    return levelUp.requiredScore;
            }

            return 0;
        }

        public bool IsMaxLevel(int currentScore) => currentScore >= _levelUps.Last().requiredScore;

    }
}


