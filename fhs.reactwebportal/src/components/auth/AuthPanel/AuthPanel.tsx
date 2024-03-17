import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardMedia from '@mui/material/CardMedia';
import * as React from 'react';
import './AuthPanel.scss';


function AuthPanel()
{
    const tabs = {
        login: 1,
        registration: 2
    }
    const [value, setValue] = React.useState(tabs.login);

    const handleChange = (newValue: number) =>
    {
        setValue(newValue);
    };


    return (

        <Card
            className='auth-panel-container'
            sx={{
                borderRadius: 1,
                display: 'flex'
            }}>
            <CardMedia
                className='auth-panel-photo'
                component="img"
                image="src/assets/AuthPageImage.jpg"
            />
            <Box
                className='auth-panel-action'
                sx={{
                    width: '100%', typography: 'body1'
                }}>
                <Box
                    className='auth-panel-tabs'>
                    <Box
                        className={value === tabs.login ? 'auth-active-tab' : 'auth-tab'}
                        onClick={() => handleChange(tabs.login)}>
                        <p>Logowanie</p>

                    </Box>
                    <Box
                        className={value === tabs.registration ? 'auth-active-tab' : 'auth-tab'}
                        onClick={() => handleChange(tabs.registration)}>
                        <p>Rejestracja</p>

                    </Box>
                </Box>
                <Box
                    className={value === tabs.login ? 'auth-panel-login' : 'auth-panel-registration'}>
                    <Box
                        className={value === tabs.login ? 'auth-active-content' : 'auth-content'}>
                        HelloWorld
                    </Box>
                    <Box
                        className={value === tabs.registration ? 'auth-active-content' : 'auth-content'}>
                        HelloWorld2
                    </Box>
                </Box>
            </Box>
        </Card>

    );
}



export default AuthPanel;