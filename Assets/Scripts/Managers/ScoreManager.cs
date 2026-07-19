using UnityEngine;
using System;

    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;
        public static event Action OnScoreAchieved;

        int score;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            score = 0;
        }
    
        public void AddScore(int scoreAmount)
        {
            score += scoreAmount;
            Debug.Log("Score: " + score);

            if (score >= 10)
            {
                Debug.Log("You win!"); 
                OnScoreAchieved?.Invoke();
                ResetScore();
            }
        }
    
        public void ResetScore()
        {
            score = 0;
        }
}    


