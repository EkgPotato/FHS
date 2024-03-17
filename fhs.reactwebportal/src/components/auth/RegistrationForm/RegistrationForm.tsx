
import PersonAddIcon from '@mui/icons-material/PersonAdd';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
import AuthEmailTextField from '../AuthElements/AuthEmailTextField';
import AuthPasswordTextField from '../AuthElements/AuthPasswordTextField';
import './RegistrationForm.scss';

function RegistrationForm()
{

    return (
        <Container>
            <Box
                className='registration-form-wrapper'>
                <PersonAddIcon
                    className='registration-form-person-icon' />
                <Box
                    component="form"
                    noValidate>
                    <AuthEmailTextField />
                    <AuthPasswordTextField />
                    <AuthPasswordTextField
                    />

                    <Button
                        size='large'
                        className="registration-form-login-button"
                        variant="contained">
                        Zarejestruj
                    </Button>
                </Box>
            </Box>
        </Container>

    );
}

export default RegistrationForm;