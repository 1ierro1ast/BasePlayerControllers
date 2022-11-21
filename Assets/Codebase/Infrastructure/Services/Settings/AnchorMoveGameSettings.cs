using Codebase.Core.Gameplay.Controllers;
using Codebase.Core.Gameplay.Controllers.RunnerController;
using UnityEngine;

namespace Codebase.Infrastructure.Services.Settings
{
    public partial class GameSettings
    {
        [SerializeField] private MoveSettings _moveSettings;

        public MoveSettings MoveSettings => _moveSettings;
    }
}