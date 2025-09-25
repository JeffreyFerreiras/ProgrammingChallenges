namespace MinStack;

public class MinStack
{
    private Stack<int> _stack = new();
    private int _min = int.MaxValue;

    public void Push(int val)
    {
        _min = Math.Min(val, _min);
        _stack.Push(val);
    }

    public void Pop()
    {
        int num = _stack.Pop();
        if (_stack.Count > 0)
            _min = _stack.Min();
        else
            _min = int.MaxValue;
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMin()
    {
        return _min;
    }
}

