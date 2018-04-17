const homeController = {}

homeController.showHome = (context) => {
  context.loadPartials({
    footer: './templates/common/footer.hbs',
    loginForm: './templates/forms/login.hbs',
    registerForm: './templates/forms/register.hbs'
  })
    .then(function () {
      this.partial('./templates/welcomePage.hbs')
    })
}
