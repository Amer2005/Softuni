function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchArgument = document.getElementById("searchField").value;

      let table = document.getElementsByTagName("tbody")[0];
      let rows = table.getElementsByTagName("tr");

      for(let i = 0;i < rows.length;i++)
      {
         rows[i].classList.remove("select");
         let cols = rows[i].getElementsByTagName("td");

         for(let j = 0;j < cols.length;j++)
         {
            if(cols[j].innerText.includes(searchArgument))
            {
               rows[i].classList.add("select");
            }
         }
      }
   }
}