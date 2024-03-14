import LoginForm from '../../components/auth/LoginForm/LoginForm';
import AuthPanel from '../../components/auth/AuthPanel/AuthPanel';
import SubmitForm from '../../components/auth/SubmitForm/SubmitForm';
import './AuthPage.css';

function AuthPage()
{
    return (
        <AuthPanel
            login={<LoginForm />}
            submit={<SubmitForm />}
        />
    );
}

export default AuthPage;