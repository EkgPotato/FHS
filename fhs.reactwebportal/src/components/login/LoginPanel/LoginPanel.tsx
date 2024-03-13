import { useState } from "react";
import './LoginPanel.css';

function LoginPanel()
{
    const [toggleState, setToggleState] = useState(1)

    const toggleTab = (index: number) => setToggleState(index)

  return (
      <div className='login-panel-container'>
          <div className='login-panel-photo'>
          </div>
          <div className='login-panel-action'>
              <div
                  className='login-panel-tabs'>
                  <div
                      className={toggleState === 1 ? 'login-active-tab' : 'login-tab'}
                      onClick={() => toggleTab(1)}>
                      Logowanie
                  </div>
                  <div
                      className={toggleState === 2 ? 'login-active-tab' : 'login-tab'}
                      onClick={() => toggleTab(2)}>
                      Rejestracja
                  </div>
              </div>
              <div className='login-panel-content'>
                  <div
                      className={toggleState === 1 ? 'login-active-content' : 'login-content'}
                  >Hello World</div> 
                  <div
                      className={toggleState === 2 ? 'login-active-content' : 'login-content'}
                  >Hello World2</div> 
              </div>
          </div>
      </div>
  );
}

export default LoginPanel;