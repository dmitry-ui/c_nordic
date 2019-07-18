using System;
class Stack
{
    class MyStack
    {
        //массив и и его вершина
        private char[] ch; //массив элементов стека
        private int top; //индекс незаполненного элемента
        private int maxtop; // максимальное количество элементов в стеке
        //конструктор
        public MyStack(int index)
        {
            ch = new char[index];
            top = 0;
            maxtop = index;
        }
        //поместим символ в стек
        public void SetSymbolToStack(char ch)
        {
            if (top < maxtop)
            {
                this.ch[top] = ch;
                top = top + 1;
            }
            else
            {
                Console.WriteLine("Ошибка переполнения стека");
            }
        }
        //считать символ из стека
        public void GetSymbolFromStack()
        {
            if (top > 0)
            {
                top = top - 1;
                Console.WriteLine("Считали из стека символ {0}", ch[top]);
            }
            else
            {
                Console.WriteLine("Стек еще не заполнен. Чтение символа невозможно.");
            }
        }
        //получим индекс последнего элемента стека
        public void GetIndexInStack()
        {
            if (top > 0)
                Console.WriteLine("Индекс последнего элемента в стеке {0}", top - 1);
            else
            {
                Console.WriteLine("Стек еще не заполнен. Чтение индекса невозможно");
            }
        }
        //получим количество элементов в стеке
        public void GetCountElementsInStack()
        {
            Console.WriteLine("Количество элементов в стеке {0}", top);
        }
        //получим емкость стека
        public void GetMaxElementsInStack()
        {
            Console.WriteLine("Емкость стека {0}", maxtop);
            
        }

    }

    static void Main ()
    {
        MyStack st = new MyStack(5);
        st.GetCountElementsInStack();
        st.GetSymbolFromStack();
        st.GetIndexInStack();
        st.GetMaxElementsInStack();

        Console.WriteLine();
        Console.WriteLine("поместим в стек элемент");
        st.SetSymbolToStack('a');
        st.GetCountElementsInStack();
        st.GetIndexInStack();
        st.GetMaxElementsInStack();
        st.GetSymbolFromStack();
        st.GetCountElementsInStack();
        st.GetIndexInStack();
        st.GetMaxElementsInStack();

        Console.WriteLine();
        Console.WriteLine("поместим в стек 2 элемента");
        st.SetSymbolToStack('a');
        st.SetSymbolToStack('в');
        st.GetCountElementsInStack();
        st.GetIndexInStack();
        st.GetMaxElementsInStack();
        st.GetSymbolFromStack();
        st.GetCountElementsInStack();
        st.GetIndexInStack();
        st.GetMaxElementsInStack();
        st.GetSymbolFromStack();
        st.GetCountElementsInStack();
        st.GetIndexInStack();
        st.GetMaxElementsInStack();


        Console.ReadKey();
    }


}
