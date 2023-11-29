# tailwind-merge-nuget
A TailwindCSS class merge utility similar to Shadcn UI / Tailwind Merge

**NOTE** this is a __very__ simple implementation of Tailwind class merging and likely has many, many edge cases that are not covered.   It is a simple implementation that works for my current use case. If you find a bug, please submit a PR with a test case and I will strive to update this package. 

## Usage
```csharp
@using TailwindMerge
@{
    var conditionalCheck = true;
}

<div class="@TW.Merge(
    "bg-red-500", 
    "text-white", 
    conditionalCheck ? "p-4" : "p-2",
    "flex flex-col justify-center items-center"
)">
    Hello World
</div>
```

Tests being implemented to match https://github.com/dcastil/tailwind-merge/tree/main/tests