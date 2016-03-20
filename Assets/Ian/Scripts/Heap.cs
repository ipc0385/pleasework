using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Heap<Type> where Type : IComparable
{
	int _count;
	Type[] _data;

	public Heap(int size = 1)
	{
		_data = new Type[size];
		_count = 0;
	}

	public Heap(params Type[] data)
	{
		_data = data;
		_count = data.Length;
	}

	public Heap(Type[] data, int size = -1)
	{
		_data = data;
		_count = size == -1 ? data.Length : size;
	}

	bool isHeap(int index)
	{
		if(index < _count)
		{
			int child = (1 + (index << 1));

			if (child < _count)
			{
				if (_data[index].CompareTo(_data[child]) <= 0)
				{
					if (child + 1 < _count)
					{
						if (_data[index].CompareTo(_data[child + 1]) <= 0)
						{
							return isHeap(child + 1);
						}
						else
						{
							return false;
						}
					}

					return isHeap(child);
				}
				else
				{
					return false;
				}
			}

		}

		return true;
	}

	public bool IsHeap
	{
		get
		{
			return isHeap(0);
		}
	}

	public bool IsFull
	{
		get
		{
			return _count == _data.Length;
		}
	}
	
	public bool IsEmpty
	{
		get
		{
			return _count == 0;
		}
	}
	
	public int Count
	{
		get
		{
			return _count;
		}
	}

	public string str
	{
		get
		{

			string sum = "{";

			for (int i = 0; i < _count; ++i) sum += _data[i].ToString() + ", ";

			return sum + "}";
		}
	}

	public void Add(Type input)
	{
		//adds the 'value' to the heap in a right order
		//works faster if you build the heap starting with the lighter values first
		if (IsFull)
		{
			//Array<Type>::Resize(Array<Type>::Capacity() * 2);
			Type[] temp = new Type[_count * 2];

			for(int i = 0; i < _count; ++i)
			{
				temp[i] = _data[i];
			}

			_data = temp;
		}
		
		int index = _count;

		if(!IsEmpty)
		{
			do
			{
				int parent_index = (index - 1) >> 1;

				//if (input < Array<Type>::operator[](parent(index)))
				if (input.CompareTo(_data[parent_index]) < 0)
				{
					//Array<Type>::operator[](index) = Array<Type>::operator[](parent(index));
					_data[index] = _data[parent_index];

					//index = parent(index);
					index = parent_index;

					continue;
				}

				break;
			} while (index > 0);

			//Array<Type>::operator[](index) = input;
			_data[index] = input;
		}

		_count++;
	}

	public Type Peak
	{
		get
		{
			return IsEmpty ? default(Type) : _data[0];
		}

		set
		{
			if(!IsEmpty)
			{
				_data[0] = value;
			}
		}
	}
	
	public void Pop ()
	{
		//returns false if the heap was empty to begin with
		//removes the value at the top of the heap
		if (IsEmpty)
		{
			return;
		}

		_count--;
		
		int index = 0;

		while (index < _count)
		{
			//int child = left_child(index);
			int child = (1 + (index << 1));

			//if (Array<Type>::operator[](child + 1) < Array<Type>::operator[](child))
			if (child + 1 < _count && _data[child + 1].CompareTo(_data[child]) < 0)
				child++;

			if (child > _count)
				break;

			//if (Array<Type>::operator[](child) < Array<Type>::operator[](_count))
			if (_data[child].CompareTo(_data[_count]) < 0)
			{
				//Array<Type>::operator[](index) = Array<Type>::operator[](child);
				_data[index] = _data[child];

				index = child;

				continue;
			}

			break;
		}

		//Array<Type>::operator[](index) = Array<Type>::operator[](_count);
		_data[index] = _data[_count];

		return;
	}
}
