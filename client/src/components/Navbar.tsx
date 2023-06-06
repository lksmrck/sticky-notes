/* 
import { Button } from "@mui/material"; */
import Button from "./Button"

const Navbar = () => {
  return (
  

<div>
    <div className="w-full flex justify-between p-4">
        <h1>Ahoj</h1>
       {/*  <Button className="rounded-full border border-blue-950 bg-blue-950 py-1.5 px-5 text-white transition-all hover:bg-slate-900 text-center text-sm  flex items-center justify-center">
            Sign Out
          </Button> */}
          <Button red={true}/>
    </div>
    
</div>
 
  )
}

export default Navbar