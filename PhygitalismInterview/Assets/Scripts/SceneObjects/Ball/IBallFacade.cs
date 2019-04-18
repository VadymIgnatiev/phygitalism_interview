using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.SceneObjects.Ball
{
    public interface IBallFacade
    {
        int BallIndex { get; }
        Transform Transform { get; }
        /// <summary>
        /// Adjust ball Speed in the range from 0 to max ball speed via linear interpolation
        /// </summary>
        /// <param name="value">an be in the range from 0 to 1</param>
        void AdjustBallSpeed(float value);
        void Init(BallSettings ballSettings, ITrajectoryDataSource trajectorySource, int ballIndex);
    }
}
