'use client';
import * as React from "react";

const App = () => {
    const [open, setOpen] = React.useState(false);

    const handleOpen = () => {
        setOpen((prevState) => !prevState);
    }
    return;
    <div>
        <button onClick={handleOpen}>Dropdown</button>
    </div>
}
export default App;