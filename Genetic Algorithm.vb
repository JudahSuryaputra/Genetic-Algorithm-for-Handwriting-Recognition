Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class BinaryChromosome
    Implements IComparable
    Public genes As Boolean()
    Public fitnessLevel As Double

    Public Sub New()
        fitnessLevel = 0
    End Sub

    Public Sub New(bitArray As Boolean())
        Me.genes = bitArray
        fitnessLevel = 0
    End Sub

    Public Function Clone() As BinaryChromosome
        Dim o As New BinaryChromosome(Me.genes)
        Return o
    End Function

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Dim other As BinaryChromosome = TryCast(obj, BinaryChromosome)
        If Me.fitnessLevel < other.fitnessLevel Then
            Return -1
        ElseIf Me.fitnessLevel = other.fitnessLevel Then
            Return 0
        Else
            Return 1
        End If

    End Function
End Class

Public Class Genetic_Algorithm
    Private randomizer As Random
    Private data As ResultData()
    Private method As CrossoverMethod

    Public Sub New(data As ResultData(), method As CrossoverMethod)
        Me.randomizer = New Random()
        Me.data = data
        Me.method = method
    End Sub

    Public Function Run(source As Boolean(), maxIteration As Integer) As String
        Dim answer As String = ""
        Dim maxFitness As Double = 0
        For i As Integer = 0 To data.Length - 1
            Dim fitness As Double = CountFitness(source, data(i).chromosome)
            If fitness > maxFitness Then
                maxFitness = fitness
                answer = data(i).character
            End If
        Next

        Dim sourceChromosome As New BinaryChromosome(source)
        sourceChromosome.fitnessLevel = maxFitness
        Dim pairChromosome As BinaryChromosome = Inverse(sourceChromosome)
        pairChromosome.fitnessLevel = 0
        Dim reverseChromosome As BinaryChromosome = Reverse(sourceChromosome)
        reverseChromosome.fitnessLevel = 0
        Dim reverseInverseChromosome As BinaryChromosome = Reverse(pairChromosome)
        reverseInverseChromosome.fitnessLevel = 0
        Dim listChromosome As New List(Of BinaryChromosome)()
        listChromosome.Add(sourceChromosome)
        listChromosome.Add(pairChromosome)
        listChromosome.Add(reverseChromosome)
        listChromosome.Add(reverseInverseChromosome)
        For i As Integer = 0 To maxIteration - 1
            Dim listCrossover As List(Of BinaryChromosome) = New List(Of BinaryChromosome)()
            For j As Integer = 0 To listChromosome.Count - 1
                For k As Integer = j + 1 To listChromosome.Count - 1
                    Dim x As BinaryChromosome = listChromosome(j)
                    Dim y As BinaryChromosome = listChromosome(k)
                    If method = CrossoverMethod.OnePoint Then
                        listCrossover.AddRange(OnePointCrossover(x, y))
                    ElseIf method = CrossoverMethod.TwoPoint Then
                        listCrossover.AddRange(TwoPointCrossover(x, y))
                    Else
                        listCrossover.AddRange(UniformCrossover(x, y))
                    End If
                Next
            Next
            listChromosome.AddRange(listCrossover)

            Dim listMutation As List(Of BinaryChromosome) = New List(Of BinaryChromosome)()
            For j As Integer = 0 To 5
                For Each chromosome As BinaryChromosome In listChromosome
                    listMutation.Add(Mutation(chromosome))
                Next
            Next
            listChromosome.AddRange(listMutation)
            For Each chromosome As BinaryChromosome In listChromosome
                Dim tempBestFitness As Double = 0
                For j As Integer = 0 To data.Length - 1
                    Dim fitness As Double = CountFitness(chromosome.genes, data(j).chromosome)
                    If fitness > maxFitness Then
                        maxFitness = fitness
                        answer = data(j).character
                    End If
                    If fitness > tempBestFitness Then
                        tempBestFitness = fitness
                    End If
                Next
                chromosome.fitnessLevel = tempBestFitness
            Next
            listChromosome.Sort()
            listChromosome.Reverse()
            listChromosome.RemoveRange(5, listChromosome.Count - 5)
        Next
        Return answer
    End Function

    Public Function CountFitness(a As Boolean(), b As Boolean()) As Double
        Dim n As Integer = a.Length
        Dim sum As Double = 0
        For i As Integer = 0 To n - 1
            If a(i) <> b(i) Then
                sum += 1
            End If
        Next
        Return (1.0 / (sum + 1))
    End Function

    Public Function Reverse(x As BinaryChromosome) As BinaryChromosome
        Dim n As Integer = x.genes.Length
        Dim bit As Boolean() = New Boolean(n - 1) {}
        x.genes.CopyTo(bit, 0)
        Array.Reverse(bit)
        Return New BinaryChromosome(bit)
    End Function

    Public Function Inverse(x As BinaryChromosome) As BinaryChromosome
        Dim n As Integer = x.genes.Length
        Dim bit As Boolean() = New Boolean(n - 1) {}
        x.genes.CopyTo(bit, 0)
        For i As Integer = 0 To n - 1
            bit(i) = Not bit(i)
        Next
        Return New BinaryChromosome(bit)
    End Function

    Public Function OnePointCrossover(a As BinaryChromosome, b As BinaryChromosome) As List(Of BinaryChromosome)
        Dim n As Integer = a.genes.Length
        Dim crossoverPoint As Integer = randomizer.[Next](n)
        Dim aBit As Boolean() = a.genes
        Dim bBit As Boolean() = b.genes
        Dim newChromosome1 As Boolean() = New Boolean(n - 1) {}
        Dim newChromosome2 As Boolean() = New Boolean(n - 1) {}

        For i As Integer = 0 To crossoverPoint - 1
            newChromosome1(i) = aBit(i)
            newChromosome2(i) = bBit(i)
        Next
        For i As Integer = crossoverPoint To n - 1
            newChromosome1(i) = bBit(i)
            newChromosome2(i) = aBit(i)
        Next
        Dim result As New List(Of BinaryChromosome)()
        result.Add(New BinaryChromosome(newChromosome1))
        result.Add(New BinaryChromosome(newChromosome2))
        Return result
    End Function

    Public Function TwoPointCrossover(a As BinaryChromosome, b As BinaryChromosome) As List(Of BinaryChromosome)
        Dim n As Integer = a.genes.Length
        Dim firstCrossoverPoint As Integer = randomizer.[Next](0, n - 1)
        Dim secondCrossoverPoint As Integer = randomizer.[Next](firstCrossoverPoint + 1, n)
        Dim aBit As Boolean() = a.genes
        Dim bBit As Boolean() = b.genes
        Dim newChromosome1 As Boolean() = New Boolean(n - 1) {}
        Dim newChromosome2 As Boolean() = New Boolean(n - 1) {}
        For i As Integer = 0 To firstCrossoverPoint - 1
            newChromosome1(i) = aBit(i)
            newChromosome2(i) = bBit(i)
        Next
        For i As Integer = firstCrossoverPoint To secondCrossoverPoint - 1
            newChromosome1(i) = bBit(i)
            newChromosome2(i) = aBit(i)
        Next
        For i As Integer = secondCrossoverPoint To n - 1
            newChromosome1(i) = aBit(i)
            newChromosome2(i) = bBit(i)
        Next
        Dim result As New List(Of BinaryChromosome)()
        result.Add(New BinaryChromosome(newChromosome1))
        result.Add(New BinaryChromosome(newChromosome2))
        Return result
    End Function

    Public Function UniformCrossover(a As BinaryChromosome, b As BinaryChromosome) As List(Of BinaryChromosome)
        Dim n As Integer = a.genes.Length
        Dim aBit As Boolean() = a.genes
        Dim bBit As Boolean() = b.genes
        Dim newChromosome1 As Boolean() = New Boolean(n - 1) {}
        Dim newChromosome2 As Boolean() = New Boolean(n - 1) {}
        For i As Integer = 0 To n - 1
            If randomizer.NextDouble() > 0.5 Then
                newChromosome1(i) = bBit(i)
                newChromosome2(i) = aBit(i)
            Else
                newChromosome1(i) = aBit(i)
                newChromosome2(i) = bBit(i)
            End If
        Next
        Dim result As New List(Of BinaryChromosome)()
        result.Add(New BinaryChromosome(newChromosome1))
        result.Add(New BinaryChromosome(newChromosome2))
        Return result
    End Function

    Public Function Mutation(source As BinaryChromosome) As BinaryChromosome
        Dim n As Integer = source.genes.Length
        Dim newGene As Boolean() = New Boolean(n - 1) {}
        source.genes.CopyTo(newGene, 0)
        Dim x As Integer = randomizer.[Next](n)
        newGene(x) = Not source.genes(x)
        Return New BinaryChromosome(newGene)
    End Function
End Class

