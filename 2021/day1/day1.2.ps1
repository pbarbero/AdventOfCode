$lines = Get-Content ".\input.txt"
$count = 0;
$previousMeasure = $null;

for ($i = 2; $i -lt $lines.Length; $i++) {
    $measure = [int]$lines[$i] + [int]$lines[$i-1] + [int]$lines[$i-2];

    If($null -ne $previousMeasure) {
        If($measure -gt $previousMeasure ){
            $count++
        }
    }

    $previousMeasure = $measure
}

Write-Host $count 