using Codebase.Core.Gameplay.Controller;
using UnityEngine;

namespace Codebase.Infrastructure.Services.Settings
{
    public partial class GameSettings
    {
        [SerializeField] private MoveSettings _moveSettings;

        public MoveSettings MoveSettings => _moveSettings;
    }
}