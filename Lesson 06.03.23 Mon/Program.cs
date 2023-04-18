// свойства, индексаторы, шаблоны, делегаты, Псевдонимы типов и статический импорт 






DMath operation1 = delegate (int x) { return x + x; };
int resultSum = operation1(5);

DMath operation2 = Multiplication;
int resultMultiplication = operation2(5);

Console.WriteLine(resultSum);
Console.WriteLine(resultMultiplication);

int Multiplication(int x) => x * x;

delegate int DMath(int x);
delegate string Str();








/*ListC<string> list = new ListC<string>();
list.Add("1").Add("2").Add("3").Add("4");
Console.WriteLine(list[1]);
list[1] = "9";
Console.WriteLine(list[1]);*/


public class ListC<T>
{
    private delegate bool DForEachItem(ListItem item);

    public T? this[uint index]
    {
        get => GetByIndex(index);
        set
        {
            if(GetItemForIndex(index) is ListItem item)
                item.Data = value ?? item.Data;
        } 
    } 

    public int Count => GetCount();

    ListItem? First { get; set; }

    public ListC<T> Where()
    {
        ListC<T> result = new ListC<T>();
        for (ListItem item = First; item is not null; item = item?.next)
        {

        }
        return result;
    }

    private void ForEachItem(DForEachItem callback)
    {
        for (ListItem? item = First; item is not null; item = item?.next)
        {
            if (!callback(item)) break;
        }
    }

    public int GetCount()
    {
        int count = 0;

        ForEachItem(delegate (ListItem item)
        {
            count++;
            return true;
        });

        return count;
    }

    public T? GetByIndex(uint index)
    {
        ListItem? item = this.GetItemForIndex(index);
        return item is null ? default(T?) : item.Data;
    }

    public int? IndexAt(int data) 
    {
        int? index = null;

        ForEachItem(delegate (ListItem item)
        {
            if (item?.Data?.Equals(data) ?? false) return false;
            index++;

            return true;
        });

        return index;
    }

    public ListC<T> Remove(T data)
    {
        ListItem? previous = null;

        if (First?.Data?.Equals(data) ?? false)
        {
            First = First?.next;
            return this;
        }

        for (ListItem? i = First?.next; i is not null; i = i?.next)
        {
            if (i?.Data?.Equals(data) ?? false)
            {
                previous!.next = i.next;
                return this;
            }

            previous = i;
        }

        return this;
    }

    public ListC<T> RemoveAt(uint index)
    {
        if (index == 0)
        {
            First = First?.next;
            return this;
        }

        ListItem? previous = this.GetItemForIndex(index - 1);
        if(previous?.next == null) return this;
        previous.next = previous.next.next;

        return this;
    }

    public ListC<T> AddRange(ListC<T> list)
    {
        this.GetLast().next = list?.First;

        return this;
    }

    public ListC<T> Add(T data)
    {
        ListItem item = new ListItem(data);

        ListItem? last = GetLast();

        if(last is null)
            First = item;
        else
        {
            last.next = item;
        }

        return this;
    }

    private ListItem? GetLast() 
    {
        ListItem? last = First;

        for ( ListItem? i = First; i is not null; i = i.next)
        {
            last = i;
        }

        return last;
    }

    public void Write()
    {
        for (ListItem? i = First; i is not null; i = i.next)
        {
            Console.Write($"{i.Data}, ");
        }
        Console.WriteLine();
    }
     
    private ListItem? GetItemForIndex(uint index)
    {
        ListItem? item = First;

        for (int i = 0; i < index && item is not null; i++)
            item = item?.next;

        return item;
    }

    class ListItem
    {
        public T Data { get; set; }
        public ListItem? next { get; set; }

        public ListItem(T data)
        {
            this.Data = data;
        }
    }
} 

