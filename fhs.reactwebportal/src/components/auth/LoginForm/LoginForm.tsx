import PersonIcon from '@mui/icons-material/Person';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
import AuthEmailTextField from '../AuthElements/AuthEmailTextField';
import AuthPasswordTextField from '../AuthElements/AuthPasswordTextField';
import './LoginForm.scss';

function LoginForm()
{
    return (
        <Container>
            <Box
                className='login-form-wrapper'>
                <PersonIcon
                    className='login-form-person-icon' />
                <Box
                    component="form"
                    noValidate>
                    <AuthEmailTextField />
                    <AuthPasswordTextField />
                </Box>
                <Button
                    size='large'
                    className="login-form-login-button"
                    variant="contained">
                    Zaloguj
                </Button>
            </Box>
        </Container>
    );
}

export default LoginForm;