using Codebase.Infrastructure.Services.Input;
using UnityEngine;

namespace Codebase.Infrastructure.Services.Settings
{
    public partial class GameSettings
    {
        [SerializeField] private InputSettings _inputSettings;
        public InputSettings InputSettings => _inputSettings;
    }
}