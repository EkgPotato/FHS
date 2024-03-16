import { useState } from "react";
import './AuthPanel.scss';
import AuthTabs from "../AuthStore/AuthStore";

function AuthPanel(tabs: AuthTabs)
{
    const [toggleState, setToggleState] = useState(1)

    const toggleTab = (index: number) => setToggleState(index)

  return (
      <div className='auth-panel-container'>
          <div className='auth-panel-photo'>
          </div>
          <div className='auth-panel-action'>
              <div
                  className='auth-panel-tabs'>
                  <div
                      className={toggleState === 1 ? 'auth-active-tab' : 'auth-tab'}
                      onClick={() => toggleTab(1)}>
                      <p>Logowanie</p>
                      
                  </div>
                  <div
                      className={toggleState === 2 ? 'auth-active-tab' : 'auth-tab'}
                      onClick={() => toggleTab(2)}>
                      <p>Rejestracja</p>
                      
                  </div>
              </div>
              <div className='auth-panel-content'>
                  <div
                      className={toggleState === 1 ? 'auth-active-content' : 'auth-content'}>
                      {tabs.login}
                      </div> 
                  <div
                      className={toggleState === 2 ? 'auth-active-content' : 'auth-content'}>
                      {tabs.submit}
                  </div> 
              </div>
          </div>
      </div>
  );
}

export default AuthPanel;