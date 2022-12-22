function LoginClick() {
    document.getElementById('LogInOrSignUp').innerHTML = document.getElementById('Login').innerHTML;
}
function SignupClick() {
    document.getElementById('LogInOrSignUp').innerHTML = document.getElementById('Signup').innerHTML;
}
function ChangeColor(id1,id2) {
    document.getElementById(id1).style.backgroundColor = 'black';
    document.getElementById(id1).style.color = 'white';
    document.getElementById(id2).style.backgroundColor = 'white';
    document.getElementById(id2).style.color = 'black';

}