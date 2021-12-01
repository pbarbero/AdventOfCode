$lines = Get-Content ".\input.txt"
# $lines = Get-Content ".\test.txt"
$count = 1;

for ($i = 1; $i -lt $lines.Length; $i++) {
    $firstItem = $lines[$i-1]
    $secondItem = $lines[$i]
    If($secondItem -gt $firstItem)
    {
        $count++;
    }
}

Write-Host $count 