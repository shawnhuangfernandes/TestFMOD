using System.Collections.Generic;
using PirateJam.Scripts.App;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PirateJam.Scripts
{
    public abstract class WorkStation : MonoBehaviour
    {
        [SerializeField] protected GameObject screen;
        [SerializeField,Range(0,3)] protected int WorkStationNumber;
        
        //To be ignored until stretch goals
        [field: SerializeField] public int Level { get; protected set; }

        [SerializeField] protected MentorReaction mentor;
        
        public struct Grade
        {
            public string Cause;
            public int Value;
        }

        [SerializeField] private List<Grade> _demerits = new();
        [SerializeField] private List<Grade> _achievements = new();

        public int Score { get; protected set; }
        public virtual void Open()
        {
            //Swap State
            GameManager.Instance.SwapGameState(GameManager.GameState.WorkStation, WorkStationNumber);
            
            //Open scene
            screen.SetActive(true);
            
            _demerits.Clear();
            _achievements.Clear();
        }
        
        public virtual int AddDemerit(Grade demerit)
        {
            _demerits.Add(demerit);
            
            Score -= demerit.Value;
            return Score;
        }

        public virtual int AddAchievement(Grade achievement)
        {
            _achievements.Add(achievement);
            Score += achievement.Value;
            return Score;
        }

        public virtual void Evaluate()
        {
            //TODO: list demerits
            
            //TODO: publish score
        }

        public virtual void Close()
        {
            GameManager.Instance.SwapGameState(GameManager.GameState.Move);
            
            screen.SetActive(false);
            
            //TODO: Store Score
            
            //TODO: evaluate if it goes to the next level

        }
    }
}
