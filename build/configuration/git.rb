configs ={
  :git => {
    :user => '20111017remote',
    :remotes => %w[rbohnet squillman alleyoopgarnett ccarrozza],
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
