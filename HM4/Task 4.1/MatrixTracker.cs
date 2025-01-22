namespace Task4
{
    internal class MatrixTracker<T>
    {
 
        readonly DiagonalMatrix<T> _matrixReference;
        Stack<ElementChangedArgs<T>> _history;
        
        private void HandlerToElementChangedEvent(object? sender, ElementChangedArgs<T> args)
        {
            _history.Push(args);
        }
        public MatrixTracker(DiagonalMatrix<T> matrix) 
        {
            
            _matrixReference = matrix;
            _history = new Stack<ElementChangedArgs<T>>();
            matrix.ElementChanged += HandlerToElementChangedEvent;
        }
        public void Undo()
        {
            if(_matrixReference != null && _history.Count != 0) 
            {
                var undoElement = _history.Pop();
                _matrixReference.ElementChanged -= HandlerToElementChangedEvent;
                _matrixReference[undoElement.Index,undoElement.Index] = undoElement.OldValue;
                _matrixReference.ElementChanged += HandlerToElementChangedEvent;
            }
        }
        
    }
}
