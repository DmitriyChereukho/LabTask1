using System;

namespace _Source.Core.Scripts
{
    public class ObservableInt
    {
        private int _value;
        public event Action<int> OnValueChanged;

        public int Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public ObservableInt(int value = 0)
        {
            _value = value;
        }
    }
}