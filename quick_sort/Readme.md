Реализован алгоритм быстрой сортировки со следующими улучшениями:
* Опорный элемент выбирается, как медиана из трех случайно выбранных элементов массива
* Рекурсивный вызов происходит только для меньшей половины
* При достижении размера < MinBlockSize происходит переключение на сортировку вставками 


Запуск 

```
dotnet run ArraySize MinBlockSize
```
Проведены измерения времени работы и количества сравнений для масиивов разной длины при разном MinBlockSize:

#### ArraySize = 1000

| SortType        | WorkTime           | ComparesNumber  |
| :-: |:-:| :-:|
| Standard Library QuickSort     | 4.7 ms | 11659 |
| My QuickSort with MinBlockSize =  1  | 1.4 ms | 16425 |
| My QuickSort with MinBlockSize =  10 | 0.9 ms | 12308 |
| My QuickSort with MinBlockSize =  20 | 0.7 ms | 12610 |
| My QuickSort with MinBlockSize =  50 | 0.56 ms | 15422 |
| My QuickSort with MinBlockSize =  100 | 0.7 ms | 23398 |

#### ArraySize = 1000000

| SortType        | WorkTime           | ComparesNumber  |
| :-: |:-:| :-:|
| Standard Library QuickSort     | 205.1 ms | 23539688 |
| My QuickSort with MinBlockSize =  1  | 1006.7 ms | 28284525 |
| My QuickSort with MinBlockSize =  10 | 496.4 ms | 24307746 |
| My QuickSort with MinBlockSize =  20 | 384.3 ms | 24496713 |
| My QuickSort with MinBlockSize =  50 | 331.7 ms | 28485963 |
| My QuickSort with MinBlockSize =  100 | 373.8 ms | 35251038 |

Исходя из приведенных таблиц можно сказать, что оптимальный выбор MinBlockSize = 50. 

Однако при таком выборе размера не достигается минимум числа сравнений. Т.е. агоритмически данный выбор блока не является оптимальным. Из этого может следовать вывод о том, что оптимум при таком выборе размера блока достигается за счёт того, что он удачно ложится L1-кэш процессора, что аппаратно ускоряет сортировку вставками для него.   

Также отметим, что на массиве малого размера данная реализация QuickSort обгоняла сортировку из стандартной библиотеке, но на массиве большого размера отставала от неё в 1,7 раза. 