using Assets.Scripts.Data;
using Assets.Scripts.SceneObjects.Ball.Actions;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Ball
{
    public class BallActionManager
    {
        private IBallAction m_CurrentAction;        
        private Dictionary<BallActions, IBallAction> m_Actions;
        private BallActions m_CurrentActionType;
        private BallInputHandler m_BallInputHandler;

        public BallActionManager(BallFacade ball, ITrajectoryDataSource trajectorySource, BallInputHandler ballInputHandler, BallSettings ballSettings)
        {
            m_Actions = new Dictionary<BallActions, IBallAction>();
            m_Actions.Add(BallActions.Idle, new IdleAction());
            m_Actions.Add(BallActions.Moving, new MoveDrawTrajectoryAction(ball, trajectorySource, ballSettings));
            m_Actions.Add(BallActions.MoveToTrajectoryStart, new MoveToTrajectoryStart(ball, trajectorySource));            

            SetAction(BallActions.MoveToTrajectoryStart);

            m_BallInputHandler = ballInputHandler;
            m_BallInputHandler.SingleMouseClick += ProcessSingleMouseClick;
            m_BallInputHandler.DoubleMouseClick += ProcessDoubleMouseClick;
        }            

        public void SetAction(BallActions action)
        {
            m_CurrentActionType = action;
            m_CurrentAction = m_Actions[action];
            m_CurrentAction.StartAction();
        }

        public void Update()
        {
            if (!m_CurrentAction.IsComplited)
            {
                m_CurrentAction.Update();
            }
            else
            {
                SetAction(BallActions.Idle);
            }
        }

        public void ProcessSingleMouseClick()
        {
            if (m_CurrentActionType == BallActions.Idle)
            {
                SetAction(BallActions.Moving);
            }
        }

        public void ProcessDoubleMouseClick()
        {
            SetAction(BallActions.MoveToTrajectoryStart);            
        }
    }
}
