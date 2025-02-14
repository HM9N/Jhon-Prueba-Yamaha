import { useState } from 'react'
import PruebaYamaha from './components/PruebaYamaha'

import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    <PruebaYamaha/>
    </>
  )
}

export default App
