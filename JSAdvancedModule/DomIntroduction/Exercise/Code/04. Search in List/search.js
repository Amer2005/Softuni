function search() {
   let items = document.getElementsByTagName("li");
   let searchTerm = document.getElementById("searchText").value;

   for(let i = 0;i < items.length;i++)
   {
      items[i].style.textDecoration = "none";
      items[i].style.fontWeight = "normal";
   }

   let matches = 0;

   for(let i = 0;i < items.length;i++)
   {
      if(items[i].innerText.includes(searchTerm))
      {
         items[i].style.textDecoration = "underline";
         items[i].style.fontWeight = "bold";
         matches++;
         //items[i].innerHTML =  `<b>${items[i].innerText}</b>`;
      }
   }

   let matchesCountElement =  document.getElementById("result");

   matchesCountElement.innerText = `${matches} matches found`;
}
